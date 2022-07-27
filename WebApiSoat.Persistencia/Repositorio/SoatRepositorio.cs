using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Interface.Repositorio;
using WebApiSoat.Core.Modelos;
using WebApiSoat.Core.OData;

namespace WebApiSoat.Persistencia.Repositorio
{
    internal class SoatRepositorio : ISoatRepositorio
    {
        private readonly DbSoatContext _DbSoatContext;
        private readonly IMapper _IMapper;
        public SoatRepositorio(DbSoatContext DbSoatContext, IMapper IMapper)
        {
            _DbSoatContext = DbSoatContext;
            _IMapper = IMapper;
        }

        public async Task<Soat> BuscarPorAsync(Expression<Func<Soat, bool>> Funcion = null)
        {
            Soat Result = default;
            try
            {
                var Qry = _DbSoatContext.Soat.AsQueryable();
                if (Funcion != default)
                {
                    Qry = Qry.Where(Funcion);
                }
                Result = await Qry.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                //_Loger
            }
            return Result;
        }

        public async Task<Soat> GuardarAsync(Soat Soat)
        {
            _DbSoatContext.Add(Soat);
            await _DbSoatContext.SaveChangesAsync();
            return Soat;
        }

        public async Task<IEnumerable<Soat>> ListarPorAsync(Expression<Func<Soat, bool>> Funcion = null)
        {
            IEnumerable<Soat> Result = default;
            try
            {
                var Qry = _DbSoatContext.Soat.AsQueryable();
                if (Funcion != default)
                {
                    Qry.Where(Funcion);
                }
                Result = await Qry.ToListAsync();
            }
            catch (Exception ex)
            {
                //_Loger
            }
            return Result;
        }

        public async Task<InformacionSoatOData> SeleccionarInformacionSoatPorAsync(Expression<Func<InformacionSoatOData, bool>> Funcion = null)
        {
            InformacionSoatOData Resultado = default;
            try
            {
                var Qry = _DbSoatContext.Soat.ProjectTo<InformacionSoatOData>(_IMapper.ConfigurationProvider);
                if (Funcion != default)
                {
                    Qry = Qry.Where(Funcion);
                }
                Resultado = await Qry.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                //_Loger
            }
            return Resultado;
        }
    }
}
