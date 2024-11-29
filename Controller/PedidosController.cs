using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidosController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public IActionResult GetPedidos()
        {
            var pedidos = _pedidoService.GetAllPedidos();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPedidoById(int id)
        {
            var pedido = _pedidoService.GetPedidoById(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult AddPedido(Pedido pedido)
        {
            _pedidoService.AddPedido(pedido);
            return CreatedAtAction(nameof(GetPedidoById), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePedido(int id, Pedido pedidoAtualizado)
        {
            var pedido = _pedidoService.GetPedidoById(id);
            if (pedido == null)
                return NotFound();

            // Atualizar campos do pedido, conforme o que está no banco
            pedido.ClienteId = pedidoAtualizado.ClienteId;
            pedido.DataPedido = pedidoAtualizado.DataPedido;
            pedido.Total = pedidoAtualizado.Total;
            // Se tiver outros campos, adicione aqui...

            _pedidoService.UpdatePedido(pedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            var pedido = _pedidoService.GetPedidoById(id);
            if (pedido == null)
                return NotFound();

            _pedidoService.DeletePedido(id);
            return NoContent();
        }

    [HttpPatch("{pedidoId}/produto/{produtoId}")]
public IActionResult AtualizarProdutoDoPedido(int pedidoId, int produtoId, [FromBody] int novoProdutoId)
{
    try
    {
        _pedidoService.AtualizarProdutoDoPedido(pedidoId, produtoId, novoProdutoId);

        return Ok(new
        {
            mensagem = "Produto atualizado com sucesso no pedido."
        });
    }
    catch (Exception ex)
    {
        return BadRequest(new { mensagem = ex.Message });
    }
}
    }
}
