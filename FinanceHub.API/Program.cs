using System.Text;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using FinanceGub.Application;
using FinanceGub.Application.Identity;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure;
using FinanceHub.Infrastructure.Data;
using FinanceHub.Infrastructure.Services;
using FinanceHub.Middleware;
using FinanceHub.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

string connectionString,
    jwtIssuerSecret,
    jwtAudienceSecret,
    jwtKeySecret,
    blobStorageConnectionString,
    containerName,
    googleClientId,
    googleClientSecret;

try
{
    var keyVaultUrl = new Uri($"https://{builder.Configuration["FinHubKeyVault"]}.vault.azure.net/");
    var client = new SecretClient(keyVaultUrl, new DefaultAzureCredential());

    connectionString = (await client.GetSecretAsync("DbConnectionString")).Value.Value;
    jwtIssuerSecret = (await client.GetSecretAsync("JwtIssuer")).Value.Value;
    jwtAudienceSecret = (await client.GetSecretAsync("JwtAudience")).Value.Value;
    jwtKeySecret = (await client.GetSecretAsync("JwtKey")).Value.Value;
    googleClientId = (await client.GetSecretAsync("GoogleClientId")).Value.Value;
    googleClientSecret = (await client.GetSecretAsync("GoogleClientSecret")).Value.Value;
    //pictures
    blobStorageConnectionString = (await client.GetSecretAsync("AzureBlobStorageConnectionString")).Value.Value;
    containerName = (await client.GetSecretAsync("ProfilePicturesContainer")).Value.Value;

    builder.Services.AddTransient<IAzureBlobStorageService>(provider =>
        new AzureBlobStorageService(blobStorageConnectionString, containerName));

    builder.Configuration["JwtKey"] = jwtKeySecret;
    builder.Configuration["JwtIssuer"] = jwtIssuerSecret;
    builder.Configuration["JwtAudience"] = jwtAudienceSecret;
    builder.Configuration["AzureBlobStorageConnectionString"] = blobStorageConnectionString;
    builder.Configuration["ProfilePicturesContainer"] = containerName;
    builder.Configuration["GoogleClientId"] = googleClientId;
    builder.Configuration["GoogleClientSecret"] = googleClientSecret;
}
catch (Exception ex)
{
    Console.WriteLine($"Error retrieving secrets from Key Vault: {ex.Message}");
    throw;
}

if (builder.Environment.IsDevelopment())
{
    connectionString = "Host=localhost;Port=5432;Database=finhub;Username=finhub;Password=finhub";
}

builder.Services.AddDbContext<FinHubDbContext>(options =>
    options.UseNpgsql(connectionString));

// Register Identity with custom User and Role types
builder.Services.AddIdentity<User, AppRole>(options => 
    {
        // Configure Identity options if needed
    })
    .AddRoles<AppRole>() // Specify the role type (AppRole)
    .AddEntityFrameworkStores<FinHubDbContext>()
    .AddRoleManager<RoleManager<AppRole>>() // Register the custom RoleManager
    .AddUserManager<UserManager<User>>() // Optional, to explicitly register the custom UserManager
    .AddDefaultTokenProviders(); 

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuerSecret,
            ValidAudience = jwtAudienceSecret,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKeySecret))
        };
    });

// Налаштування аутентифікації через Google
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = googleClientId;
        options.ClientSecret = googleClientSecret;
        options.CallbackPath = "/user";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(IdentityData.AdminUserPolicyName, p =>
        p.RequireClaim(IdentityData.AdminUserClaimName, "true"));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200") // or .AllowAnyOrigin() for dev
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Pagination");
    });
});


var app = builder.Build();

app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); });
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();