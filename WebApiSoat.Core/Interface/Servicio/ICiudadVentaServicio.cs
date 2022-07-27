using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSoat.Core.Interface.Servicio
{
    public interface ICiudadVentaServicio
    {
        Task<bool> CiudadActivaParaCompra(int IdCiudadVenta);
        Task<IEnumerable> CiudadesVenta();
    }
}
