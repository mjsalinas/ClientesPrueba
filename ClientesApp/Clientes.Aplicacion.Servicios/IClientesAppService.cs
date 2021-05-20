using ClientesApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApp.Clientes.Aplicacion.Servicios
{
    public interface IClientesAppService
    {
        public List<ClienteDTO> ObtenerClientes();
        public ClienteDTO ObtenerClienteId(ObtenerClienteIdRequest request);
        public ClienteDTO ModificarCliente(ModificarClienteRequest request);

        public ClienteDTO CrearCliente(CrearClienteRequest request);
    }
}
