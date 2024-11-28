using PizzariaBackend.AppDbContexts;
using PizzariaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzariaBackend.Services
{
    public class CuponsService
    {
        private readonly AppDbContext _context;

        public CuponsService(AppDbContext context)
        {
            _context = context;
        }

        // Obter todos os cupons
        public async Task<IEnumerable<Cupom>> GetAllAsync()
        {
            return await _context.Cupons.ToListAsync();
        }

        // Obter um cupom pelo ID
        public async Task<Cupom?> GetByIdAsync(int id)
        {
            return await _context.Cupons.FindAsync(id);
        }

        // Adicionar um novo cupom
        public async Task AddAsync(Cupom cupom)
        {
            _context.Cupons.Add(cupom);
            await _context.SaveChangesAsync();
        }

        // Atualizar um cupom
        public async Task UpdateAsync(Cupom cupom)
        {
            _context.Cupons.Update(cupom);
            await _context.SaveChangesAsync();
        }

        // Deletar um cupom
        public async Task DeleteAsync(int id)
        {
            var cupom = await _context.Cupons.FindAsync(id);
            if (cupom != null)
            {
                _context.Cupons.Remove(cupom);
                await _context.SaveChangesAsync();
            }
        }
    }
}
