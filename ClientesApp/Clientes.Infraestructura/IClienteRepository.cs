using ClientesApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApp.Clientes.Infraestructura
{
    public interface IClienteRepository
    {
        public List<ClienteDTO> ObtenerClientes();

        public ClienteDTO ObtenerClientePorId(int idCliente);

        public ClienteDTO CrearCliente(ClienteDTO clienteNuevo);

        public ClienteDTO ModificarCliente(ClienteDTO clienteNuevo);
    }
}
