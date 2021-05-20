using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApp.DTOs
{
    public class ClientesRequest
    {
    }
    public class ObtenerClienteIdRequest
    {
        public int Idclientes;
    }

    public class ModificarClienteRequest
    {
        public int Idclientes ;
        public string Nombrel ;
        public DateTime? Fechanacimiento ;
        public string Estadocivil ;
        public short? Activo ;
    }
    public class CrearClienteRequest
    {
        public string Nombrel;
        public DateTime? Fechanacimiento;
        public string Estadocivil;
        public short? Activo;
    }
}
