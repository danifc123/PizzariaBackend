using PizzariaBackend.AppDbContexts;
using PizzariaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzariaBackend.Services
{
    public class PedidosService
    {
        private readonly AppDbContext _context;

        public PedidosService(AppDbContext context)
        {
            _context = context;
        }

        // Retorna todos os pedidos
        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // Retorna um pedido por ID
        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        // Adiciona um novo pedido
        public async Task AddAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        // Atualiza um pedido existente
        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        // Remove um pedido por ID
        public async Task DeleteAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
