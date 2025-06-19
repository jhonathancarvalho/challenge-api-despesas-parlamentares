using DespesasParlamentares.API.Infrastructure.Context;
using DespesasParlamentares.API.Infrastructure.Repository;
using DespesasParlamentares.API.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DespesasParlamentares.API.Extensions
{
    public static class InfrastructureServicesExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDeputadoRepository, DeputadoRepository>();
            services.AddScoped<IDespesaRepository, DespesaRepository>();

            return services;
        }
    }
}