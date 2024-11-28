using PizzariaBackend.Data;
using PizzariaBackend.Models;

namespace PizzariaBackend.Services
{
    public class ProdutoService
    {
        private readonly DataStore _dataStore;

        public ProdutoService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Produto> ListarProdutos()
        {
            return _dataStore.Produtos;
        }

        public Produto? BuscarPorId(int id)
        {
            return _dataStore.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public void AdicionarProduto(Produto produto)
        {
            produto.Id = _dataStore.Produtos.Count > 0 ? _dataStore.Produtos.Max(p => p.Id) + 1 : 1;
            _dataStore.Produtos.Add(produto);
        }

        public bool AtualizarProduto(int id, Produto produtoAtualizado)
        {
            var produto = BuscarPorId(id);
            if (produto == null) return false;

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            produto.Descricao = produtoAtualizado.Descricao;
            produto.SubcategoriaId = produtoAtualizado.SubcategoriaId;

            return true;
        }

        public bool RemoverProduto(int id)
        {
            var produto = BuscarPorId(id);
            if (produto == null) return false;

            _dataStore.Produtos.Remove(produto);
            return true;
        }
    }
}
