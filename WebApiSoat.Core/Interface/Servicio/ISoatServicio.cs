using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.Modelos;
using WebApiSoat.Core.OData;
using WebApiSoat.Core.ViewModels;

namespace WebApiSoat.Core.Interface.Servicio
{
    public interface ISoatServicio
    {
        Task<bool> ValidarVigencia(string Placa, DateTime FechaVencimineto);
        Task<VmSoatResponse> RealizaCompra(VmSoatRequest Soat);
        Task<InformacionSoatOData> SeleccionarInformacionSoatPorPlacaAsync(string Placa);
    }
}
