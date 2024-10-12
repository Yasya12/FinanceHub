using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Servises;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Infrastructure.Data;
using FinanceHub.Infrastructure.Repositories;
using FinanceHub.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceHub.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IUserService, UserService>(); 
        serviceCollection.AddScoped<IJwtService, JwtService>();
    }
    
    
}