using PizzariaBackend.AppDbContexts;
using PizzariaBackend.Models;

namespace PizzariaBackend.Services // Verifique se o namespace está correto
{
    public class ProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> GetAllProdutos()
        {
            return _context.Produtos.ToList();
        }

        public Produto? GetProdutoById(int id)
        {
            return _context.Produtos.Find(id);
        }

        public void AddProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void UpdateProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public void DeleteProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }
    }
}
