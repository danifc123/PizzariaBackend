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
    
    public void AtualizarProdutoDoPedido(int pedidoId, int produtoAntigoId, int produtoNovoId)
{
    // Buscar o pedido
    var pedido = _context.Pedidos.Find(pedidoId);
    if (pedido == null)
        throw new Exception("Pedido não encontrado.");

    // Verificar se o produto está no pedido
    var index = pedido.Produtos.IndexOf(produtoAntigoId);
    if (index == -1)
        throw new Exception("Produto não encontrado no pedido.");

    // Atualizar o produto na lista
    pedido.Produtos[index] = produtoNovoId;

    // Salvar alterações no banco
    _context.Pedidos.Update(pedido);
    _context.SaveChanges();
}
}
