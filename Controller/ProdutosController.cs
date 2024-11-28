using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;
using PizzariaBackend.Services;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult GetProdutos()
        {
            var produtos = _produtoService.GetAllProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(int id)
        {
            var produto = _produtoService.GetProdutoById(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult AddProduto(Produto produto)
        {
            _produtoService.AddProduto(produto);
            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, Produto produtoAtualizado)
        {
            var produto = _produtoService.GetProdutoById(id);
            if (produto == null)
                return NotFound();

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            _produtoService.UpdateProduto(produto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            var produto = _produtoService.GetProdutoById(id);
            if (produto == null)
                return NotFound();

            _produtoService.DeleteProduto(id);
            return NoContent();
        }
    }
}
