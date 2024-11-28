using Microsoft.EntityFrameworkCore;
using PizzariaBackend.Models;

namespace PizzariaBackend.AppDbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public required DbSet<Usuario> Usuarios { get; set; }
        public required DbSet<Produto> Produtos { get; set; }
        public required DbSet<Cliente> Clientes { get; set; }
        public required DbSet<Categoria> Categorias { get; set; }
        public required DbSet<Subcategoria> Subcategorias { get; set; }
        public required DbSet<Cupom> Cupons { get; set; }
        public required DbSet<Pedido> Pedidos { get; set; }
        public required DbSet<Configuracoes> Configuracoes { get; set; }
    }
}
