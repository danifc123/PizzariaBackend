using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;
using PizzariaBackend.Services;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            var clientes = _clienteService.GetAllClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            var cliente = _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult AddCliente(Cliente cliente)
        {
            _clienteService.AddCliente(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, Cliente clienteAtualizado)
        {
            var cliente = _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;
            _clienteService.UpdateCliente(cliente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();

            _clienteService.DeleteCliente(id);
            return NoContent();
        }
    }
}
