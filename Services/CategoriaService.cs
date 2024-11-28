using PizzariaBackend.AppDbContexts;
using PizzariaBackend.Models;

public class CategoriaService
{
    private readonly AppDbContext _context;

    public CategoriaService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Categoria> GetAllCategorias()
    {
        return _context.Categorias.ToList();
    }

    public Categoria? GetCategoriaById(int id)
    {
        return _context.Categorias.Find(id);
    }

    public void AddCategoria(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
    }

    public void UpdateCategoria(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        _context.SaveChanges();
    }

    public void DeleteCategoria(int id)
    {
        var categoria = _context.Categorias.Find(id);
        if (categoria != null)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }
    }
}
