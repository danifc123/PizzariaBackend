using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoriasController : ControllerBase
    {
        public static List<Subcategoria> Subcategorias = new List<Subcategoria>();

        [HttpGet]
        public IActionResult GetSubcategorias()
        {
            return Ok(Subcategorias);
        }

        [HttpPost]
        public IActionResult AddSubcategoria(Subcategoria subcategoria)
        {
            subcategoria.Id = Subcategorias.Count + 1;
            Subcategorias.Add(subcategoria);
            return CreatedAtAction(nameof(GetSubcategoriaById), new { id = subcategoria.Id }, subcategoria);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubcategoriaById(int id)
        {
            var subcategoria = Subcategorias.FirstOrDefault(s => s.Id == id);
            if (subcategoria == null)
                return NotFound();

            return Ok(subcategoria);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubcategoria(int id, Subcategoria subcategoriaAtualizada)
        {
            var subcategoria = Subcategorias.FirstOrDefault(s => s.Id == id);
            if (subcategoria == null)
                return NotFound();

            subcategoria.Nome = subcategoriaAtualizada.Nome;
            subcategoria.CategoriaId = subcategoriaAtualizada.CategoriaId;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubcategoria(int id)
        {
            var subcategoria = Subcategorias.FirstOrDefault(s => s.Id == id);
            if (subcategoria == null)
                return NotFound();

            Subcategorias.Remove(subcategoria);
            return NoContent();
        }
    }
}
