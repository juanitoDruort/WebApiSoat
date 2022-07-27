using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSoat.Core.OData
{
    public class InformacionSoatOData
    {
        public string Identificacion { get; set; }
        public string NombreApellido { get; set; }
        public DateTime FechaVenciminetoNuevaPoliza { get; set; }
        public string Placa { get; set; }
    }
}
