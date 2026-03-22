using LYS.Locadora.Application.Services;
using LYS.Locadora.Application.Services.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LYS.Locadora.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IMovieService,MovieService>();
    }
    
}