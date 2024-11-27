namespace PizzariaBackend.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public List<int> Produtos { get; set; } = new List<int>(); // IDs dos produtos
        public decimal Total { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
