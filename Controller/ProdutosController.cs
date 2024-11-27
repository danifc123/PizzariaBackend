using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        public static List<Produto> Produtos = new List<Produto>();

        [HttpGet]
        public IActionResult GetProdutos()
        {
            return Ok(Produtos);
        }

        [HttpPost]
        public IActionResult AddProduto(Produto produto)
        {
            produto.Id = Produtos.Count + 1;
            Produtos.Add(produto);
            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.Id }, produto);
        }

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(int id)
        {
            var produto = Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, Produto produtoAtualizado)
        {
            var produto = Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            produto.Descricao = produtoAtualizado.Descricao;
            produto.SubcategoriaId = produtoAtualizado.SubcategoriaId;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            var produto = Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();

            Produtos.Remove(produto);
            return NoContent();
        }
    }
}
