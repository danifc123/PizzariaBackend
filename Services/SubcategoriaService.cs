using PizzariaBackend.Models;
using PizzariaBackend.AppDbContexts;
using Microsoft.EntityFrameworkCore;

namespace PizzariaBackend.Services
{
    public class SubcategoriaService
    {
        private readonly AppDbContext _context;

        public SubcategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subcategoria>> GetAllAsync()
        {
            return await _context.Subcategorias.ToListAsync();
        }

        public async Task<Subcategoria?> GetByIdAsync(int id)
        {
            return await _context.Subcategorias.FindAsync(id);
        }

        public async Task AddAsync(Subcategoria subcategoria)
        {
            _context.Subcategorias.Add(subcategoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Subcategoria subcategoria)
        {
            _context.Subcategorias.Update(subcategoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subcategoria = await _context.Subcategorias.FindAsync(id);
            if (subcategoria != null)
            {
                _context.Subcategorias.Remove(subcategoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}
