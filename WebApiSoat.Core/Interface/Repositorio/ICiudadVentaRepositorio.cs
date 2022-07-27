using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Modelos;

namespace WebApiSoat.Core.Interface.Repositorio
{
    public interface ICiudadVentaRepositorio
    {
        Task<CiudadVenta> BuscarPorAsync(Expression<Func<CiudadVenta, bool>> Funcion = null);
        Task<IEnumerable<CiudadVenta>> ListarPorAsync(Expression<Func<CiudadVenta, bool>> Funcion = null);
    }
}
