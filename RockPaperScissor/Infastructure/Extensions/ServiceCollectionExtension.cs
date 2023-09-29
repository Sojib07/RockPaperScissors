using Infastructure.BLL.IServices;
using Infastructure.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            return services;
        }
    }
}