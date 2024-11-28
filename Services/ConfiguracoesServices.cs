using PizzariaBackend.AppDbContexts;
using PizzariaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzariaBackend.Services
{
    public class ConfiguracoesService
    {
        private readonly AppDbContext _context;

        public ConfiguracoesService(AppDbContext context)
        {
            _context = context;
        }

        public List<Configuracoes> ListarConfiguracoes()
        {
            // Retorna todas as configurações do banco de dados
            return _context.Configuracoes.ToList();
        }

        public Configuracoes? BuscarPorNome(string nome)
        {
            // Busca a configuração pelo nome no banco de dados
            return _context.Configuracoes.FirstOrDefault(c => c.Nome == nome);
        }

        public void AdicionarConfiguracao(Configuracoes configuracao)
        {
            // Adiciona uma nova configuração no banco de dados
            _context.Configuracoes.Add(configuracao);
            _context.SaveChanges();
        }

        public bool AtualizarConfiguracao(int id, Configuracoes configuracaoAtualizada)
        {
            // Busca a configuração existente no banco
            var configuracao = _context.Configuracoes.FirstOrDefault(c => c.Id == id);
            if (configuracao == null) return false;

            // Atualiza os dados da configuração
            configuracao.Nome = configuracaoAtualizada.Nome;
            configuracao.Valor = configuracaoAtualizada.Valor;

            _context.Configuracoes.Update(configuracao);
            _context.SaveChanges();
            return true;
        }

        public bool RemoverConfiguracao(int id)
        {
            // Busca a configuração no banco de dados
            var configuracao = _context.Configuracoes.FirstOrDefault(c => c.Id == id);
            if (configuracao == null) return false;

            // Remove a configuração do banco
            _context.Configuracoes.Remove(configuracao);
            _context.SaveChanges();
            return true;
        }
    }
}
