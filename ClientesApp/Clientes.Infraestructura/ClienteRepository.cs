using ClientesApp.Clientes.Dominio;
using ClientesApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApp.Clientes.Infraestructura
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PruebaDAVContext db;

        public ClienteRepository(PruebaDAVContext dbContext)
        {
            db = dbContext;
        }
        ClienteDTO IClienteRepository.CrearCliente(ClienteDTO clienteNuevo)
        {
            Cliente cliente = new Cliente
            {
                Nombrel = clienteNuevo.Nombrel,
                Fechanacimiento = clienteNuevo.Fechanacimiento,
                Estadocivil = clienteNuevo.Estadocivil,
                Activo = clienteNuevo.Activo,
            };
            db.Clientes.Add(cliente);
            db.SaveChanges();
            return clienteNuevo;
        }

        ClienteDTO IClienteRepository.ModificarCliente(ClienteDTO clienteNuevo)
        {
            Cliente clienteRegistrado = db.Clientes.FirstOrDefault(cliente => cliente.Idclientes == clienteNuevo.Idclientes);

            if(clienteRegistrado == null)
            {
                return new ClienteDTO
                {
                    MensajeError = "Cliente no existe"
                };
            }
                clienteRegistrado.Idclientes = clienteNuevo.Idclientes;
                clienteRegistrado.Nombrel = clienteNuevo.Nombrel;
                clienteRegistrado.Fechanacimiento = clienteNuevo.Fechanacimiento;
                clienteRegistrado.Estadocivil = clienteNuevo.Estadocivil;
                clienteRegistrado.Activo = clienteNuevo.Activo;
            db.SaveChanges();
            return clienteNuevo;
        }

        ClienteDTO IClienteRepository.ObtenerClientePorId(int idCliente)
        {
            Cliente cliente = db.Clientes.FirstOrDefault(usuario => usuario.Idclientes == idCliente);
            return new ClienteDTO
            {
                Idclientes = cliente.Idclientes,
                Nombrel = cliente.Nombrel,
                Fechanacimiento = cliente.Fechanacimiento,
                Estadocivil = cliente.Estadocivil,
                Activo = cliente.Activo,
            };
        }

        List<ClienteDTO> IClienteRepository.ObtenerClientes()
        {
            List<ClienteDTO> clientesDTO  = new List<ClienteDTO>();
            List<Cliente> clientes = db.Clientes.ToList();

            foreach (var cliente in clientes)
            {
                clientesDTO.Add(new ClienteDTO
                {
                    Nombrel = cliente.Nombrel,
                    Fechanacimiento = cliente.Fechanacimiento,
                    Activo = cliente.Activo,
                    Estadocivil = cliente.Estadocivil,
                });
            }
            return clientesDTO;
        }
    }
}
