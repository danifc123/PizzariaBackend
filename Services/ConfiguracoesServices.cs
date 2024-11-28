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

        // Listar todas as configurações
        public List<Configuracoes> ListarConfiguracoes()
        {
            return _context.Configuracoes.ToList();
        }

        // Buscar configuração pelo nome
        public Configuracoes? BuscarPorNome(string nome)
        {
            return _context.Configuracoes.FirstOrDefault(c => c.Nome == nome);
        }

        // Adicionar uma nova configuração
        public void AdicionarConfiguracao(Configuracoes configuracao)
        {
            _context.Configuracoes.Add(configuracao);
            _context.SaveChanges();
        }

        // Atualizar uma configuração existente
        public bool AtualizarConfiguracao(int id, Configuracoes configuracaoAtualizada)
        {
            var configuracao = _context.Configuracoes.FirstOrDefault(c => c.Id == id);
            if (configuracao == null) return false;

            configuracao.Nome = configuracaoAtualizada.Nome;
            configuracao.Valor = configuracaoAtualizada.Valor;

            _context.Configuracoes.Update(configuracao);
            _context.SaveChanges();
            return true;
        }

        // Remover uma configuração
        public bool RemoverConfiguracao(int id)
        {
            var configuracao = _context.Configuracoes.FirstOrDefault(c => c.Id == id);
            if (configuracao == null) return false;

            _context.Configuracoes.Remove(configuracao);
            _context.SaveChanges();
            return true;
        }
    }
}
