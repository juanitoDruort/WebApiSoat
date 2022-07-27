using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.ViewModels;
using WebApiSoat.Validacion.Validacion.VmSoat;

namespace WebApiSoat.Validacion
{
    public static class ServiceValidacionExtensions
    {
        public static IServiceCollection AddConfiguracionValidation(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation();
            services.TryAddScoped<IValidator<VmSoatRequest>, VmSoatRequestValidacion>();
            return services;
        }
    }
}
