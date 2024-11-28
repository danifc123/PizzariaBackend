using PizzariaBackend.Data;
using PizzariaBackend.Models;

namespace PizzariaBackend.Services
{
    public class CupomService
    {
        private readonly DataStore _dataStore;

        public CupomService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Cupom> ListarCupons()
        {
            return _dataStore.Cupons;
        }

        public Cupom? BuscarPorCodigo(string codigo)
        {
            return _dataStore.Cupons.FirstOrDefault(c => c.Codigo == codigo);
        }

        public void AdicionarCupom(Cupom cupom)
        {
            cupom.Id = _dataStore.Cupons.Count > 0 ? _dataStore.Cupons.Max(c => c.Id) + 1 : 1;
            _dataStore.Cupons.Add(cupom);
        }

        public bool AtualizarCupom(int id, Cupom cupomAtualizado)
        {
            var cupom = _dataStore.Cupons.FirstOrDefault(c => c.Id == id);
            if (cupom == null) return false;

            cupom.Codigo = cupomAtualizado.Codigo;
            cupom.Desconto = cupomAtualizado.Desconto;
            cupom.Validade = cupomAtualizado.Validade;

            return true;
        }

        public bool RemoverCupom(int id)
        {
            var cupom = _dataStore.Cupons.FirstOrDefault(c => c.Id == id);
            if (cupom == null) return false;

            _dataStore.Cupons.Remove(cupom);
            return true;
        }
    }
}
