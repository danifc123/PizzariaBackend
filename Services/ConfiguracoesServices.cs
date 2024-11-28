using PizzariaBackend.Data;
using PizzariaBackend.Models;

namespace PizzariaBackend.Services
{
    public class ConfiguracoesService
    {
        private readonly DataStore _dataStore;

        public ConfiguracoesService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Configuracoes> ListarConfiguracoes()
        {
            return _dataStore.Configuracoes;
        }

        public Configuracoes? BuscarPorNome(string nome)
        {
            return _dataStore.Configuracoes.FirstOrDefault(c => c.Nome == nome);
        }

        public void AdicionarConfiguracao(Configuracoes configuracao)
        {
            configuracao.Id = _dataStore.Configuracoes.Count > 0 ? _dataStore.Configuracoes.Max(c => c.Id) + 1 : 1;
            _dataStore.Configuracoes.Add(configuracao);
        }

        public bool AtualizarConfiguracao(int id, Configuracoes configuracaoAtualizada)
        {
            var configuracao = _dataStore.Configuracoes.FirstOrDefault(c => c.Id == id);
            if (configuracao == null) return false;

            configuracao.Nome = configuracaoAtualizada.Nome;
            configuracao.Valor = configuracaoAtualizada.Valor;

            return true;
        }

        public bool RemoverConfiguracao(int id)
        {
            var configuracao = _dataStore.Configuracoes.FirstOrDefault(c => c.Id == id);
            if (configuracao == null) return false;

            _dataStore.Configuracoes.Remove(configuracao);
            return true;
        }
    }
}
