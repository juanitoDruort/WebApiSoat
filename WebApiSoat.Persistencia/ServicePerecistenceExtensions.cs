using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Interface.Repositorio;
using WebApiSoat.Persistencia.Repositorio;

namespace WebApiSoat.Persistencia
{

    public static class ServicePerecistenceExtensions
    {
        public static IServiceCollection AddConfiguracionPersistencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbSoatContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.TryAddScoped<ISoatRepositorio, SoatRepositorio>();
            services.TryAddScoped<ICiudadVentaRepositorio, CiudadVentaRepositorio>();
            services.TryAddScoped<IClienteRepositorio, ClienteRepositorio>();
            return services;
        }
    }
}
