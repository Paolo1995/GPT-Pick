using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CommonLibrary.Extensions;
public static class IServiceCollectionExtensions
{
    public static void AddCustomDbContext<TContext>(this IServiceCollection services, IConfiguration configuration) where TContext : DbContext
    {
        services.AddDbContext<TContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void AddCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });
    }
}
