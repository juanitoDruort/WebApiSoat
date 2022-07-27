using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Interface.Servicio;
using WebApiSoat.Core.ViewModels;

namespace WebApiSoat.Validacion.Validacion.VmSoat
{
    public class VmSoatRequestValidacion : AbstractValidator<VmSoatRequest>
    {
        public VmSoatRequestValidacion(ISoatServicio ISoatServicio, ICiudadVentaServicio ICiudadVentaServicio)
        {
            RuleFor(x => x.Identificacion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("no debe ser vacio {PropertyName}")
                .NotNull().WithMessage("no debe ser nulo {PropertyName}")
                .MaximumLength(10).WithMessage("Maximo de 10 digitos");

            RuleFor(x => x.Placa)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("no debe ser vacio {PropertyName}")
                .NotNull().WithMessage("no debe ser nulo {PropertyName}")
                .MaximumLength(6).WithMessage("Maximo de 6 digitos");

            RuleFor(x => x.Placa).Must((model,Placa, cancellation) =>
            {
                bool Validacion = Herramientas.RunSync(() =>  ISoatServicio.ValidarVigencia(Placa));
                return Validacion;
            }).WithMessage("La fecha actual de compra esta sobre la fecha de vigencia del soat ");

            RuleFor(x => x.IdCiuad)
                .Cascade(CascadeMode.Stop)
                .NotEqual(0).WithMessage("{PropertyName} no debe ser 0")
                .Must((model, IdCiuad, cancellation) =>
                {
                    bool Validacion = Herramientas.RunSync(() => ICiudadVentaServicio.CiudadActivaParaCompra(IdCiuad));
                    return Validacion;
                }).WithMessage("Este Id no esta valido para realizar la compra");
        }
    }
}

