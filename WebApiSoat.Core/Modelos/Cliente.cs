using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSoat.Core.Modelos
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Identificacion { get; set; }
        public string NombreApellido { get; set; }
        public List<Soat> Soats { get; set; }
    }
}
