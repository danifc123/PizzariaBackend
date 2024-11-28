using PizzariaBackend.Models;

namespace PizzariaBackend.Services
{
    public class ClienteService
    {
        private readonly List<Cliente> _clientes = new();

        public List<Cliente> ListarClientes()
        {
            return _clientes;
        }

        public Cliente? BuscarPorId(int id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        public void AdicionarCliente(Cliente cliente)
        {
            cliente.Id = _clientes.Count > 0 ? _clientes.Max(c => c.Id) + 1 : 1;
            _clientes.Add(cliente);
        }

        public bool AtualizarCliente(int id, Cliente clienteAtualizado)
        {
            var cliente = BuscarPorId(id);
            if (cliente == null) return false;

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;
            cliente.Telefone = clienteAtualizado.Telefone;
            cliente.Endereco = clienteAtualizado.Endereco;

            return true;
        }

        public bool RemoverCliente(int id)
        {
            var cliente = BuscarPorId(id);
            if (cliente == null) return false;

            _clientes.Remove(cliente);
            return true;
        }
    }
}
