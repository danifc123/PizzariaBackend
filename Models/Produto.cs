namespace PizzariaBackend.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public required string  Nome { get; set; }
        public decimal Preco { get; set; }
        public string? Descricao { get; set; }
        public int SubcategoriaId { get; set; }
    }
}
