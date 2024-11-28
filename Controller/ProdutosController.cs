using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;
using PizzariaBackend.Services; // Certifique-se de importar o namespace do serviço

namespace PizzariaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        // Injeção de dependência do ProdutoService
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

        [HttpPost]
        public IActionResult AddProduto(Produto produto)
        {
            _produtoService.AddProduto(produto);
            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.Id }, produto);
        }

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(int id)
        {
            var produto = _produtoService.GetProdutoById(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, Produto produtoAtualizado)
        {
            var produto = _produtoService.GetProdutoById(id);
            if (produto == null)
                return NotFound();

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            produto.Descricao = produtoAtualizado.Descricao;
            produto.SubcategoriaId = produtoAtualizado.SubcategoriaId;

            _produtoService.UpdateProduto(produto); // Atualiza o produto
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            var produto = _produtoService.GetProdutoById(id);
            if (produto == null)
                return NotFound();

            _produtoService.DeleteProduto(id); // Deleta o produto
            return NoContent();
        }
    }
}
