using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSoat.Core.ViewModels
{
    public class VmSoatRequest
    {
        public string Identificacion { get; set; }
        public string NombreApellido { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaVenciminetoPolizaActual { get; set; }
        public string Placa { get; set; }
        public int IdCiuad { get; set; }
    }
}
