namespace PizzariaBackend.Models
{
    public class Subcategoria
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int CategoriaId { get; set; }
    }
}
