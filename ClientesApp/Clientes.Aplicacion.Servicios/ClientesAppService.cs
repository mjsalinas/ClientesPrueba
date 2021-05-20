using ClientesApp.Clientes.Infraestructura;
using ClientesApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApp.Clientes.Aplicacion.Servicios
{
    public class ClientesAppService : IClientesAppService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClientesAppService(IClienteRepository clienteRepository)
        {
            if (clienteRepository == null) throw new ArgumentNullException("Clientes Repo");
            _clienteRepository = clienteRepository;
        }
        ClienteDTO IClientesAppService.CrearCliente(CrearClienteRequest request)
        {
            ClienteDTO clienteNuevo = new ClienteDTO
            {
                Nombrel = request.Nombrel,
                Fechanacimiento = request.Fechanacimiento,
                Estadocivil = request.Estadocivil,
                Activo = request.Activo,
            };
           ClienteDTO response = _clienteRepository.CrearCliente(clienteNuevo);
            return response;
        }

        ClienteDTO IClientesAppService.ModificarCliente(ModificarClienteRequest request)
        {
            ClienteDTO clienteNuevo = new ClienteDTO
            {
                Idclientes = request.Idclientes,
                Nombrel = request.Nombrel,
                Fechanacimiento = request.Fechanacimiento,
                Estadocivil = request.Estadocivil,
                Activo = request.Activo,
            };
            ClienteDTO response = _clienteRepository.ModificarCliente(clienteNuevo);
            return response;
        }

        ClienteDTO IClientesAppService.ObtenerClienteId(ObtenerClienteIdRequest request)
        {
            ClienteDTO response = _clienteRepository.ObtenerClientePorId(request.Idclientes);
            return response;
        }

        List<ClienteDTO> IClientesAppService.ObtenerClientes()
        {
            List<ClienteDTO> response = _clienteRepository.ObtenerClientes();
            return response;
        }
    }
}
