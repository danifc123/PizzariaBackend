using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        public static List<Cliente> Clientes = new List<Cliente>();

        [HttpGet]
        public IActionResult GetClientes()
        {
            return Ok(Clientes);
        }

        [HttpPost]
        public IActionResult AddCliente(Cliente cliente)
        {
            cliente.Id = Clientes.Count + 1;
            Clientes.Add(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            var cliente = Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, Cliente clienteAtualizado)
        {
            var cliente = Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;
            cliente.Telefone = clienteAtualizado.Telefone;
            cliente.Endereco = clienteAtualizado.Endereco;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            Clientes.Remove(cliente);
            return NoContent();
        }
    }
}
