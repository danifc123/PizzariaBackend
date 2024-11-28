using PizzariaBackend.Data;
using PizzariaBackend.Models;

namespace PizzariaBackend.Services
{
    public class SubcategoriaService
    {
        private readonly DataStore _dataStore;

        public SubcategoriaService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Subcategoria> ListarSubcategorias()
        {
            return _dataStore.Subcategorias;
        }

        public Subcategoria? BuscarPorId(int id)
        {
            return _dataStore.Subcategorias.FirstOrDefault(s => s.Id == id);
        }

        public void AdicionarSubcategoria(Subcategoria subcategoria)
        {
            subcategoria.Id = _dataStore.Subcategorias.Count > 0 ? _dataStore.Subcategorias.Max(s => s.Id) + 1 : 1;
            _dataStore.Subcategorias.Add(subcategoria);
        }

        public bool AtualizarSubcategoria(int id, Subcategoria subcategoriaAtualizada)
        {
            var subcategoria = BuscarPorId(id);
            if (subcategoria == null) return false;

            subcategoria.Nome = subcategoriaAtualizada.Nome;
            subcategoria.CategoriaId = subcategoriaAtualizada.CategoriaId;

            return true;
        }

        public bool RemoverSubcategoria(int id)
        {
            var subcategoria = BuscarPorId(id);
            if (subcategoria == null) return false;

            _dataStore.Subcategorias.Remove(subcategoria);
            return true;
        }
    }
}
