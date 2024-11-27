namespace PizzariaBackend.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
        public required string Endereco { get; set; }
    }
}
