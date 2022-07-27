using Microsoft.AspNetCore.Mvc;
using WebApiSoat.Core.Interface.Servicio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSoat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadCompraController : ControllerBase
    {
        private readonly ICiudadVentaServicio _ICiudadVentaServicio;
        public CiudadCompraController(ICiudadVentaServicio ICiudadVentaServicio)
        {
            _ICiudadVentaServicio = ICiudadVentaServicio;
        }
        // GET: api/<CiudadCompraController>
        [HttpGet]
        public async Task<ActionResult> CiudadesVenta()
        {
            return StatusCode(200, await _ICiudadVentaServicio.CiudadesVenta());
        }

    }
}
