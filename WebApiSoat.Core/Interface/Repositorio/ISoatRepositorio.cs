using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Modelos;
using WebApiSoat.Core.OData;

namespace WebApiSoat.Core.Interface.Repositorio
{
    public interface ISoatRepositorio
    {
        Task<Soat> GuardarAsync(Soat Soat);
        Task<Soat> BuscarPorAsync(Expression<Func<Soat, bool>> Funcion = null);
        Task<IEnumerable<Soat>> ListarPorAsync(Expression<Func<Soat, bool>> Funcion = null);
        Task<InformacionSoatOData> SeleccionarInformacionSoatPorAsync(Expression<Func<InformacionSoatOData, bool>> Funcion = null);
    }
}
