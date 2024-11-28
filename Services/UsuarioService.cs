using PizzariaBackend.Models;
using PizzariaBackend.AppDbContexts;

namespace PizzariaBackend.Services
{
  public class UsuarioService
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Usuario> GetUsuarios()
    {
        return _context.Usuarios.ToList();
    }

    public Usuario? GetUsuarioById(int id)
    {
        return _context.Usuarios.Find(id);
    }

    public void AddUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void DeleteUsuario(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
}


}
