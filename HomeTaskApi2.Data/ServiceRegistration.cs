using HomeTaskApi2.Core.Repositories;
using HomeTaskApi2.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HomeTaskApi2.Data;

public static class ServiceRegistration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGenreRepository, GenreRepository>();
    }
}
