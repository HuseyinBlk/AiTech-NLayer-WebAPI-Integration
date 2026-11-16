using System.Reflection;
using AiTech.Business.Services.GenericServices;
using Microsoft.Extensions.DependencyInjection;

namespace AiTech.Business.Extensions;

public static class BusinessRegistrations
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        
        services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,,>));
        
        services.Scan(scan => scan
            .FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}