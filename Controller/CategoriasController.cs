using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;

namespace PizzariaBackend.Controllers
{
  [ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly CategoriaService _categoriaService;

    public CategoriasController(CategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public IActionResult GetCategorias()
    {
        var categorias = _categoriaService.GetAllCategorias();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoriaById(int id)
    {
        var categoria = _categoriaService.GetCategoriaById(id);
        if (categoria == null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpPost]
    public IActionResult AddCategoria(Categoria categoria)
    {
        _categoriaService.AddCategoria(categoria);
        return CreatedAtAction(nameof(GetCategoriaById), new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategoria(int id, Categoria categoriaAtualizada)
    {
        var categoria = _categoriaService.GetCategoriaById(id);
        if (categoria == null)
            return NotFound();

        categoria.Nome = categoriaAtualizada.Nome;
        _categoriaService.UpdateCategoria(categoria);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategoria(int id)
    {
        var categoria = _categoriaService.GetCategoriaById(id);
        if (categoria == null)
            return NotFound();

        _categoriaService.DeleteCategoria(id);
        return NoContent();
    }
}


}
