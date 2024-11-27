using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        public static List<Pedido> Pedidos = new List<Pedido>();

        [HttpGet]
        public IActionResult GetPedidos()
        {
            return Ok(Pedidos);
        }

        [HttpPost]
        public IActionResult AddPedido(Pedido pedido)
        {
            pedido.Id = Pedidos.Count + 1;
            Pedidos.Add(pedido);
            return CreatedAtAction(nameof(GetPedidoById), new { id = pedido.Id }, pedido);
        }

        [HttpGet("{id}")]
        public IActionResult GetPedidoById(int id)
        {
            var pedido = Pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePedido(int id, Pedido pedidoAtualizado)
        {
            var pedido = Pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
                return NotFound();

            pedido.ClienteId = pedidoAtualizado.ClienteId;
            pedido.Produtos = pedidoAtualizado.Produtos;
            pedido.Total = pedidoAtualizado.Total;
            pedido.DataPedido = pedidoAtualizado.DataPedido;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            var pedido = Pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
                return NotFound();

            Pedidos.Remove(pedido);
            return NoContent();
        }
    }
}
