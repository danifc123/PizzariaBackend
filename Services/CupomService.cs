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

        public async Task<IEnumerable<Cupom>> GetAllAsync()
        {
            return await _context.Cupons.ToListAsync();
        }

        public async Task<Cupom?> GetByIdAsync(int id)
        {
            return await _context.Cupons.FindAsync(id);
        }

        public async Task AddAsync(Cupom cupom)
        {
            _context.Cupons.Add(cupom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cupom cupom)
        {
            _context.Cupons.Update(cupom);
            await _context.SaveChangesAsync();
        }

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
