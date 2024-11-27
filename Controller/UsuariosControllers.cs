using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
public static List<Usuario> Usuarios = new List<Usuario>();

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            return Ok(Usuarios);
        }

        [HttpPost]
        public IActionResult AddUsuario(Usuario usuario)
        {
            usuario.Id = Usuarios.Count + 1;
            Usuarios.Add(usuario);
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, usuario);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, Usuario usuarioAtualizado)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
                return NotFound();

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Email = usuarioAtualizado.Email;
            usuario.Senha = usuarioAtualizado.Senha;
            usuario.Regra = usuarioAtualizado.Regra;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
                return NotFound();

            Usuarios.Remove(usuario);
            return NoContent();
        }
    }
}
