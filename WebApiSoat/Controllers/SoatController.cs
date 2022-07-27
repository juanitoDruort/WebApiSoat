using Microsoft.AspNetCore.Mvc;
using WebApiSoat.Core.Interface.Servicio;
using WebApiSoat.Core.OData;
using WebApiSoat.Core.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSoat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoatController : ControllerBase
    {
        private readonly ISoatServicio _ISoatServicio;
        public SoatController(ISoatServicio ISoatServicio)
        {
            _ISoatServicio = ISoatServicio;
        }
        // GET: api/<SoatController>
        [HttpPost]
        public async Task<IActionResult> CrearSoat(VmSoatRequest vmSoatRequest)
        {
            VmSoatResponse Result = await _ISoatServicio.RealizaCompra(vmSoatRequest);
            if (Result.MensajeResponseModelo.CodHttp == 400)
            {
                return StatusCode(Result.MensajeResponseModelo.CodHttp, Result.MensajeResponseModelo.Msm);
            }
            else {
                return StatusCode(Result.MensajeResponseModelo.CodHttp, Result.VmSaveSoat);
            }
        }
        // GET: api/<SoatController>
        [HttpGet("{Placa}")]
        public async Task<IActionResult> BuscarSoat(string Placa)
        {
            InformacionSoatOData Result = await _ISoatServicio.SeleccionarInformacionSoatPorPlacaAsync(Placa);
            if (Result != null)
            {
                return StatusCode(200, Result);
            }
            else
            {
                return StatusCode(500,"Soat no encotrado");
            }
        }
    }
}
