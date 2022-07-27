using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApiSoat.Core.Interface.Servicio;
using WebApiSoat.Mapeador;
using WebApiSoat.Persistencia;
using WebApiSoat.Servicios.Servicios;
using WebApiSoat.Validacion;

namespace WebApiSoat.Servicios
{
    public static class ServiceServiciosExtensions
    {
        public static IServiceCollection AddServiciosService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddConfiguracionPersistencia(configuration);
            services.AddConfiguracionValidation();
            services.AddConfiguracionMapeador();
            services.TryAddScoped<ISoatServicio, SoatServicio>();
            services.TryAddScoped<ICiudadVentaServicio, CiudadVentaServicio>();         
            return services;
        }
    }
}
