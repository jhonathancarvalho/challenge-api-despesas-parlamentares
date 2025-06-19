using DespesasParlamentares.API.Implementation.Interface;
using DespesasParlamentares.API.Implementation.Services;

namespace DespesasParlamentares.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseDadosServices, BaseDadosServices>();
            services.AddScoped<IDeputadoServices, DeputadoServices>();

            return services;
        }
    }
}