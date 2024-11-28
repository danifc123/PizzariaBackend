using PizzariaBackend.AppDbContexts;
using PizzariaBackend.Models;

public class PedidoService
{
    private readonly AppDbContext _context;

    public PedidoService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Pedido> GetAllPedidos()
    {
        return _context.Pedidos.ToList();
    }

    public Pedido? GetPedidoById(int id)
    {
        return _context.Pedidos.Find(id);
    }

    public void AddPedido(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();
    }

    public void UpdatePedido(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        _context.SaveChanges();
    }

    public void DeletePedido(int id)
    {
        var pedido = _context.Pedidos.Find(id);
        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }
    }
}
