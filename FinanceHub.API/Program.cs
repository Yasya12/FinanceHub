using System.Text;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using FinanceGub.Application;
using FinanceGub.Application.Identity;
using FinanceHub.Infrastructure;
using FinanceHub.Infrastructure.Data;
using FinanceHub.Middleware;
using FinanceHub.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

string connectionString, jwtIssuerSecret, jwtAudienceSecret, jwtKeySecret;

try
{
    var keyVaultUrl = new Uri($"https://{builder.Configuration["FinHubKeyVault"]}.vault.azure.net/");
    var client = new SecretClient(keyVaultUrl, new DefaultAzureCredential());

    connectionString = (await client.GetSecretAsync("DbConnectionString")).Value.Value;
    jwtIssuerSecret = (await client.GetSecretAsync("JwtIssuer")).Value.Value;
    jwtAudienceSecret = (await client.GetSecretAsync("JwtAudience")).Value.Value;
    jwtKeySecret = (await client.GetSecretAsync("JwtKey")).Value.Value;

    builder.Configuration["JwtKey"] = jwtKeySecret;
    builder.Configuration["JwtIssuer"] = jwtIssuerSecret;
    builder.Configuration["JwtAudience"] = jwtAudienceSecret;
}
catch (Exception ex)
{
    Console.WriteLine($"Error retrieving secrets from Key Vault: {ex.Message}");
    throw; 
}

builder.Services.AddDbContext<FinHubDbContext>(options =>
    options.UseNpgsql(connectionString));

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

builder.Services.AddAuthorization(options => {
    options.AddPolicy(IdentityData.AdminUserPolicyName, p =>
        p.RequireClaim(IdentityData.AdminUserClaimName, "true"));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();