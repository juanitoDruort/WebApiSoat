using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSoat.Core.Modelos
{
    public class CiudadVenta
    {
        public int IdCiudadVenta { get; set; }
        public string Ciudad { get; set; }
        public bool Permitido { get; set; }
    }
}
