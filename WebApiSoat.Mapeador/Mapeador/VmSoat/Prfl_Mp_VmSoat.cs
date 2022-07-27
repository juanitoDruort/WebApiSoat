using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Modelos;
using WebApiSoat.Core.OData;
using WebApiSoat.Core.ViewModels;

namespace WebApiSoat.Mapeador.Mapeador.VmSoat
{
    public class Prfl_Mp_VmSoat : Profile
    {
        public Prfl_Mp_VmSoat()
        {
            CreateMap<VmSoatRequest, Soat>()
                .ForMember(dest => dest.PlacaAutomotor, opts => opts.MapFrom(src => src.Placa))
                .ForMember(dest => dest.IdCiudadVenta, opts => opts.MapFrom(src => src.IdCiuad));
            CreateMap<VmSoatRequest, Cliente>();


            CreateMap<Soat, InformacionSoatOData>()
                .ForMember(dest => dest.Identificacion, opts => opts.MapFrom(src => src.Cliente.Identificacion))
                .ForMember(dest => dest.FechaVenciminetoNuevaPoliza, opts => opts.MapFrom(src => src.FechaVenciminetoPolizaActual.AddMonths(12)))
                .ForMember(dest => dest.Placa, opts => opts.MapFrom(src => src.PlacaAutomotor))
                .ForMember(dest => dest.NombreApellido, opts => opts.MapFrom(src => src.Cliente.NombreApellido));
        }
    }
}
