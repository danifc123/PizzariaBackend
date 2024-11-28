using PizzariaBackend.Data;
using PizzariaBackend.Models;

namespace PizzariaBackend.Services
{
    public class CategoriaService
    {
        private readonly DataStore _dataStore;

        public CategoriaService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Categoria> ListarCategorias()
        {
            return _dataStore.Categorias;
        }

        public Categoria? BuscarPorId(int id)
        {
            return _dataStore.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            categoria.Id = _dataStore.Categorias.Count > 0 ? _dataStore.Categorias.Max(c => c.Id) + 1 : 1;
            _dataStore.Categorias.Add(categoria);
        }

        public bool AtualizarCategoria(int id, Categoria categoriaAtualizada)
        {
            var categoria = BuscarPorId(id);
            if (categoria == null) return false;

            categoria.Nome = categoriaAtualizada.Nome;

            return true;
        }

        public bool RemoverCategoria(int id)
        {
            var categoria = BuscarPorId(id);
            if (categoria == null) return false;

            _dataStore.Categorias.Remove(categoria);
            return true;
        }
    }
}
