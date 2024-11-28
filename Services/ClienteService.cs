using PizzariaBackend.AppDbContexts;
using PizzariaBackend.Models;

namespace PizzariaBackend.Services;
public class ClienteService
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Cliente> GetAllClientes()
    {
        return _context.Clientes.ToList();
    }

    public Cliente? GetClienteById(int id)
    {
        return _context.Clientes.Find(id);
    }

    public void AddCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
    }

    public void UpdateCliente(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        _context.SaveChanges();
    }

    public void DeleteCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
}
