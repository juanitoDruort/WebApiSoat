using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Mapeador.Mapeador.VmSoat;

namespace WebApiSoat.Mapeador
{
    public static class ServiceMapeadorExtensions
    {
        public static IServiceCollection AddConfiguracionMapeador(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Prfl_Mp_VmSoat));
            return services;
        }
    }
}
