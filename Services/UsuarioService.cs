using PizzariaBackend.Data;
using PizzariaBackend.Models;

namespace PizzariaBackend.Services
{
    public class UsuarioService
    {
        private readonly DataStore _dataStore;

        public UsuarioService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Usuario> ListarUsuarios()
        {
            return _dataStore.Usuarios;
        }

        public Usuario? BuscarPorId(int id)
        {
            return _dataStore.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            usuario.Id = _dataStore.Usuarios.Count > 0 ? _dataStore.Usuarios.Max(u => u.Id) + 1 : 1;
            _dataStore.Usuarios.Add(usuario);
        }

        public bool AtualizarUsuario(int id, Usuario usuarioAtualizado)
        {
            var usuario = BuscarPorId(id);
            if (usuario == null) return false;

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Email = usuarioAtualizado.Email;
            usuario.Senha = usuarioAtualizado.Senha;
            usuario.Regra = usuarioAtualizado.Regra;

            return true;
        }

        public bool RemoverUsuario(int id)
        {
            var usuario = BuscarPorId(id);
            if (usuario == null) return false;

            _dataStore.Usuarios.Remove(usuario);
            return true;
        }
    }
}
