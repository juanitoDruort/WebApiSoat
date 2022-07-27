using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Interface.Repositorio;
using WebApiSoat.Core.Interface.Servicio;
using WebApiSoat.Core.Modelos;

namespace WebApiSoat.Servicios.Servicios
{
    public class CiudadVentaServicio : ICiudadVentaServicio
    {
        private readonly ICiudadVentaRepositorio _ICiudadVentaRepositorio;
        public CiudadVentaServicio(ICiudadVentaRepositorio ICiudadVentaRepositorio)
        {
            _ICiudadVentaRepositorio = ICiudadVentaRepositorio;
        }

        public async Task<bool> CiudadActivaParaCompra(int IdCiudadVenta)
        {
            return (await _ICiudadVentaRepositorio.BuscarPorAsync(Ciudad => Ciudad.IdCiudadVenta == IdCiudadVenta && Ciudad.Permitido)) != null ? true : false;
        }

        public async Task<IEnumerable> CiudadesVenta()
        {
            return await _ICiudadVentaRepositorio.ListarPorAsync();
        }
    }
}
