using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;
using PizzariaBackend.Services;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoriasController : ControllerBase
    {
        private readonly SubcategoriaService _subcategoriaService;

        public SubcategoriasController(SubcategoriaService subcategoriaService)
        {
            _subcategoriaService = subcategoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubcategorias()
        {
            var subcategorias = await _subcategoriaService.GetAllAsync();
            return Ok(subcategorias);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubcategoria([FromBody] Subcategoria subcategoria)
        {
            await _subcategoriaService.AddAsync(subcategoria);
            return CreatedAtAction(nameof(GetSubcategoriaById), new { id = subcategoria.Id }, subcategoria);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubcategoriaById(int id)
        {
            var subcategoria = await _subcategoriaService.GetByIdAsync(id);
            if (subcategoria == null)
                return NotFound();
            return Ok(subcategoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubcategoria(int id, [FromBody] Subcategoria subcategoriaAtualizada)
        {
            var subcategoria = await _subcategoriaService.GetByIdAsync(id);
            if (subcategoria == null)
                return NotFound();

            subcategoria.Nome = subcategoriaAtualizada.Nome;
            subcategoria.CategoriaId = subcategoriaAtualizada.CategoriaId;

            await _subcategoriaService.UpdateAsync(subcategoria);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubcategoria(int id)
        {
            var subcategoria = await _subcategoriaService.GetByIdAsync(id);
            if (subcategoria == null)
                return NotFound();

            await _subcategoriaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
