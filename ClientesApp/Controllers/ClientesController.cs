using ClientesApp.Clientes.Aplicacion.Servicios;
using ClientesApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApp.Clientes.Aplicacion.ServiciosDistribuidos
{
    [Route("clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesAppService _clientesAppService;
        public ClientesController(IClientesAppService clientesAppService)
        {
            _clientesAppService = clientesAppService;
        }
        [HttpGet]
        public IActionResult ObtenerClientes()
        {
            List<ClienteDTO> clientes = _clientesAppService.ObtenerClientes();
            return Ok(clientes);
        }
        [HttpGet("{id}")]
        public IActionResult ObtenerClientePorId(int id)
        {
            ObtenerClienteIdRequest request = new ObtenerClienteIdRequest
            {
                Idclientes = id,
            };
            ClienteDTO clientes = _clientesAppService.ObtenerClienteId(request);
            if (string.IsNullOrEmpty(clientes.MensajeError))
            {
                return Ok(clientes);
            }
            return BadRequest(clientes);
        }
        [HttpPost]
        public IActionResult CrearCliente([FromBody] CrearClienteRequest request)
        {
            ClienteDTO cliente = _clientesAppService.CrearCliente(request);
            if (string.IsNullOrEmpty(cliente.MensajeError))
            {
                return Ok(cliente);
            }
            return BadRequest(cliente);
        }
        [HttpPut]
        public IActionResult ModificarCliente([FromBody] ModificarClienteRequest request)
        {
            ClienteDTO cliente = _clientesAppService.ModificarCliente(request);
            if (string.IsNullOrEmpty(cliente.MensajeError))
            {
                return Ok(cliente);
            }
            return BadRequest(cliente);
        }

    }
}
