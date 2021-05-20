using System;
using System.Collections.Generic;

#nullable disable

namespace ClientesApp.Clientes.Dominio
{
    public partial class Cliente
    {
        public int Idclientes { get; set; }
        public string Nombrel { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public string Estadocivil { get; set; }
        public short? Activo { get; set; }
    }
}
