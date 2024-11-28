using PizzariaBackend.Models;

namespace PizzariaBackend.Data
{
    public class DataStore
    {
        // Listas para armazenar os dados
        public List<Usuario> Usuarios { get; } = new();
        public List<Cliente> Clientes { get; } = new();
        public List<Produto> Produtos { get; } = new();
        public List<Categoria> Categorias { get; } = new();
        public List<Subcategoria> Subcategorias { get; } = new();
        public List<Cupom> Cupons { get; } = new();
        public List<Pedido> Pedidos { get; } = new();
        public List<Configuracoes> Configuracoes { get; } = new();
    }
}
