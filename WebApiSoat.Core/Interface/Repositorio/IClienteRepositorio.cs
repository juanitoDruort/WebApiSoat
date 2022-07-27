using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Modelos;

namespace WebApiSoat.Core.Interface.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<Cliente> BuscarPorAsync(Expression<Func<Cliente, bool>> Funcion = null);
        Task<Cliente> GuardarAsync(Cliente Cliente);
    }
}
