using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Interface.Repositorio;
using WebApiSoat.Core.Modelos;

namespace WebApiSoat.Persistencia.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DbSoatContext _DbSoatContext;
        public ClienteRepositorio(DbSoatContext DbSoatContext)
        {
            _DbSoatContext = DbSoatContext;
        }
        public async Task<Cliente> BuscarPorAsync(Expression<Func<Cliente, bool>> Funcion = null)
        {
            Cliente Resultado = default;
            try
            {
                var Qry = _DbSoatContext.Cliente.AsQueryable();
                if (Funcion != default)
                {
                    Qry = Qry.Where(Funcion);
                }
                Resultado = await Qry.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                //_Loger.LogError(ex, $"Error al {nameof(FindByAsync)}");
            }
            return Resultado;
        }

        public async Task<Cliente> GuardarAsync(Cliente Cliente)
        {
            _DbSoatContext.Add(Cliente);
            await _DbSoatContext.SaveChangesAsync();
            return Cliente;
        }
    }
}
