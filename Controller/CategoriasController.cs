using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        public static List<Categoria> Categorias = new List<Categoria>();

        [HttpGet]
        public IActionResult GetCategorias()
        {
            return Ok(Categorias);
        }

        [HttpPost]
        public IActionResult AddCategoria(Categoria categoria)
        {
            categoria.Id = Categorias.Count + 1;
            Categorias.Add(categoria);
            return CreatedAtAction(nameof(GetCategoriaById), new { id = categoria.Id }, categoria);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoriaById(int id)
        {
            var categoria = Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoria(int id, Categoria categoriaAtualizada)
        {
            var categoria = Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
                return NotFound();

            categoria.Nome = categoriaAtualizada.Nome;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(int id)
        {
            var categoria = Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
                return NotFound();

            Categorias.Remove(categoria);
            return NoContent();
        }
    }
}
