using AiTech.WebUI.Services.CategoryServices;
using AiTech.WebUI.Services.ProjectServices;

namespace AiTech.WebUI.Extensions;

public static class ServiceRegistrations
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var baseUrl = new Uri(configuration["ApiSettings:BaseUrl"] );

        services.ConfigureHttpClientDefaults(builder =>
        {
            builder.ConfigureHttpClient(client => client.BaseAddress = baseUrl);
        });

        services.AddHttpClient<ICategoryService, CategoryService>();
        services.AddHttpClient<IProjectService, ProjectService>();

        return services;
    }
}