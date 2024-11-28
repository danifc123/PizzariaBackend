using PizzariaBackend.Data;
using PizzariaBackend.Models;

namespace PizzariaBackend.Services
{
    public class PedidoService
    {
        private readonly DataStore _dataStore;

        public PedidoService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Pedido> ListarPedidos()
        {
            return _dataStore.Pedidos;
        }

        public Pedido? BuscarPorId(int id)
        {
            return _dataStore.Pedidos.FirstOrDefault(p => p.Id == id);
        }

        public void AdicionarPedido(Pedido pedido)
        {
            pedido.Id = _dataStore.Pedidos.Count > 0 ? _dataStore.Pedidos.Max(p => p.Id) + 1 : 1;
            pedido.DataPedido = DateTime.Now;
            _dataStore.Pedidos.Add(pedido);
        }

        public bool AtualizarPedido(int id, Pedido pedidoAtualizado)
        {
            var pedido = BuscarPorId(id);
            if (pedido == null) return false;

            pedido.ClienteId = pedidoAtualizado.ClienteId;
            pedido.Produtos = pedidoAtualizado.Produtos;
            pedido.Total = pedidoAtualizado.Total;

            return true;
        }

        public bool RemoverPedido(int id)
        {
            var pedido = BuscarPorId(id);
            if (pedido == null) return false;

            _dataStore.Pedidos.Remove(pedido);
            return true;
        }
    }
}
