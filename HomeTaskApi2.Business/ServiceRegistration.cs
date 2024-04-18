using HomeTaskApi2.Business.Services.Implementations;
using HomeTaskApi2.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HomeTaskApi2.Business;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IGenreService, GenreService>();
    }
}
