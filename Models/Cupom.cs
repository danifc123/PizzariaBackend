namespace PizzariaBackend.Models
{
    public class Cupom
    {
        public int Id { get; set; }
        public required string Codigo { get; set; }
        public decimal Desconto { get; set; } // Valor ou percentual de desconto
        public DateTime Validade { get; set; }
    }
}
