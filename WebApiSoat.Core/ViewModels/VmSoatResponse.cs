using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSoat.Core.ViewModels.Response;

namespace WebApiSoat.Core.ViewModels
{
    public class VmSoatResponse
    {
        public MensajeResponseModelo MensajeResponseModelo { get; set; }
        public VmSaveSoat VmSaveSoat { get; set; }
    }

    public class VmSaveSoat
    {
        public string Identificacion { get; set; }
        public string NombreApellido { get; set; }
        public DateTime FechaVenciminetoNuevaPoliza { get; set; }
        public string Placa { get; set; }
    }
}
