using System.Reflection;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Infrastructure.Repositories;
using FinanceHub.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceHub.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IProfileRepository, ProfileRepository>();
        serviceCollection.AddScoped<IPostRepository, PostRepository>();
        
        serviceCollection.AddScoped<IUserService, UserService>(); 
        serviceCollection.AddScoped<IProfileService, ProfileService>(); 
        serviceCollection.AddScoped<IJwtService, JwtService>();
        
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
    
    
}