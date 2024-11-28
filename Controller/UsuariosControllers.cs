using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;
using PizzariaBackend.Services;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsuario([FromBody] Usuario usuario)
        {
            await _usuarioService.AddUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, usuario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuario usuarioAtualizado)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            if (usuario == null)
                return NotFound();

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Email = usuarioAtualizado.Email;
            usuario.Senha = usuarioAtualizado.Senha;
            usuario.Regra = usuarioAtualizado.Regra;

            await _usuarioService.UpdateUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            if (usuario == null)
                return NotFound();

            await _usuarioService.DeleteUsuario(id);
            return NoContent();
        }
    }
}
