using Catalog.API.Repositories;

namespace Catalog.API;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICatalogUoW, CatalogUoW>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}