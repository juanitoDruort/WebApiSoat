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
    internal class CiudadVentaRepositorio : ICiudadVentaRepositorio
    {
        private readonly DbSoatContext _DbSoatContext;
        public CiudadVentaRepositorio(DbSoatContext DbSoatContext)
        {
            _DbSoatContext = DbSoatContext;
        }
        public async Task<CiudadVenta> BuscarPorAsync(Expression<Func<CiudadVenta, bool>> Funcion = null)
        {
            CiudadVenta Result = default;
            try
            {
                var Qry = _DbSoatContext.CiudadVenta.AsQueryable();
                if (Funcion != default)
                {
                    Qry = Qry.Where(Funcion);
                }
                Result = await Qry.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                //_Loger.LogError(ex, $"Error al {nameof(FindByAsync)}");
            }
            return Result;
        }

        public async Task<IEnumerable<CiudadVenta>> ListarPorAsync(Expression<Func<CiudadVenta, bool>> Funcion = null)
        {
            IEnumerable<CiudadVenta> Result = default;
            try
            {
                var Qry = _DbSoatContext.CiudadVenta.AsQueryable();
                if (Funcion != default)
                {
                    Qry.Where(Funcion);
                }
                Result = await Qry.ToListAsync();
            }
            catch (Exception ex)
            {
                //_Loger.LogError(ex, $"Error al {nameof(FindByAsync)}");
            }
            return Result;
        }
    }
}
