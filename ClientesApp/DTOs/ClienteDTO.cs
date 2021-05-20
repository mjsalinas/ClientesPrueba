using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApp.DTOs
{
    public class ClienteDTO
    {
        public int Idclientes { get; set; }
        public string Nombrel { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public string Estadocivil { get; set; }
        public short? Activo { get; set; }
        public string MensajeError { get;  set; }
    }
}
