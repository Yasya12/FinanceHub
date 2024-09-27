using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Infrastructure.Data;
using FinanceHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceHub.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("The string is empty or null");

        serviceCollection.AddDbContext<FinHubDbContext>(options =>
            options.UseNpgsql(connectionString));
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
    }
    
    
}