using Microsoft.OpenApi.Models;

namespace DespesasParlamentares.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Despesas Parlamentares - API",
                    Version = "v1",
                    Description = "Documentação da API de Despesas Parlamentares"
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Despesas Parlamentares - API v1");
                c.RoutePrefix = "swagger";
            });

            return app;
        }
    }
}