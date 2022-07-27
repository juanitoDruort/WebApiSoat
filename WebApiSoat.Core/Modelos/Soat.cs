using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSoat.Core.Modelos
{
    public class Soat
    {
        public int IdSoat { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaVenciminetoPolizaActual { get; set; }
        public string  PlacaAutomotor { get; set; }
        public int IdCiudadVenta { get; set; }
        public Cliente Cliente { get; set; }
    }
}
