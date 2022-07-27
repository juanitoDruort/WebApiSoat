using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Interface.Repositorio;
using WebApiSoat.Core.Interface.Servicio;
using WebApiSoat.Core.Modelos;
using WebApiSoat.Core.OData;
using WebApiSoat.Core.ViewModels;

namespace WebApiSoat.Servicios.Servicios
{
    internal class SoatServicio : ISoatServicio
    {
        private readonly ISoatRepositorio _ISoatRepositorio;

        private readonly IClienteRepositorio _IClienteRepositorio;
        private readonly IMapper _IMapper;
        public SoatServicio(ISoatRepositorio ISoatRepositorio,
                            IClienteRepositorio IClienteRepositorio,
                            IMapper IMapper)
        {
            _ISoatRepositorio = ISoatRepositorio;
            _IClienteRepositorio = IClienteRepositorio;
            _IMapper = IMapper;
        }

        public async Task<VmSoatResponse> RealizaCompra(VmSoatRequest VmSoatRequest)
        {
            VmSoatResponse Resultado = new();
            Resultado.MensajeResponseModelo = new();
            Cliente Cliente = _IMapper.Map<Cliente>(VmSoatRequest);
            Cliente = await _IClienteRepositorio.BuscarPorAsync(Cli => Cli.Identificacion == Cliente.Identificacion);
            if (Cliente == null)
            {
                //Creo al Cliente
                Cliente = await _IClienteRepositorio.GuardarAsync(_IMapper.Map<Cliente>(VmSoatRequest));
                if (Cliente.IdCliente == 0)
                {
                    Resultado.MensajeResponseModelo.CodHttp = 400;
                    Resultado.MensajeResponseModelo.Msm = "No se creo el cliente";
                }
            }

            if (Cliente.IdCliente != 0)
            {
                Soat Soat = _IMapper.Map<Soat>(VmSoatRequest);
                Soat.IdCliente = Cliente.IdCliente;
                Soat = await _ISoatRepositorio.GuardarAsync(Soat);
                if (Soat.IdSoat == 0)
                {
                    Resultado.MensajeResponseModelo.CodHttp = 400;
                    Resultado.MensajeResponseModelo.Msm = "No se creo el Soat";
                }
                else
                {
                    Resultado.MensajeResponseModelo.CodHttp = 201;
                    Resultado.VmSaveSoat = new();
                    Resultado.VmSaveSoat.Identificacion = Cliente.Identificacion;
                    Resultado.VmSaveSoat.NombreApellido = Cliente.NombreApellido;
                    Resultado.VmSaveSoat.Placa = Soat.PlacaAutomotor;
                    Resultado.VmSaveSoat.FechaVenciminetoNuevaPoliza = DateTime.Now.AddMonths(12);
                }
            }
            return Resultado;
        }

        public async Task<InformacionSoatOData> SeleccionarInformacionSoatPorPlacaAsync(string Placa)
        {
            return await _ISoatRepositorio.SeleccionarInformacionSoatPorAsync(Soat => Soat.Placa == Placa);
        }

        public async Task<bool> ValidarVigencia(string Placa)
        {
            var ResConsulta = await _ISoatRepositorio.BuscarPorAsync(Soat =>
                       Soat.PlacaAutomotor.ToUpper() == Placa.ToUpper() &&
                      DateTime.Now > Soat.FechaVenciminetoPolizaActual);
            return ResConsulta != null ? true : false;
        }
    }
}
