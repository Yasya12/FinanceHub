using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace FinanceGub.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}