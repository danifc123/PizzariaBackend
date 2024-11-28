using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;
using PizzariaBackend.Services;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfiguracoesController : ControllerBase
    {
        private readonly ConfiguracoesService _configuracoesService;

        public ConfiguracoesController(ConfiguracoesService configuracoesService)
        {
            _configuracoesService = configuracoesService;
        }

        // Get todas as configurações
        [HttpGet]
        public IActionResult GetConfiguracoes()
        {
            var configuracoes = _configuracoesService.ListarConfiguracoes();
            return Ok(configuracoes);
        }

        // Adicionar uma nova configuração
        [HttpPost]
        public IActionResult AddConfiguracao(Configuracoes configuracao)
        {
            _configuracoesService.AdicionarConfiguracao(configuracao);
            return CreatedAtAction(nameof(GetConfiguracaoById), new { id = configuracao.Id }, configuracao);
        }

        // Buscar configuração por ID
        [HttpGet("{id}")]
        public IActionResult GetConfiguracaoById(int id)
        {
            var configuracao = _configuracoesService.ListarConfiguracoes().FirstOrDefault(c => c.Id == id);
            if (configuracao == null)
                return NotFound();

            return Ok(configuracao);
        }

        // Atualizar uma configuração
        [HttpPut("{id}")]
        public IActionResult UpdateConfiguracao(int id, Configuracoes configuracaoAtualizada)
        {
            var sucesso = _configuracoesService.AtualizarConfiguracao(id, configuracaoAtualizada);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }

        // Deletar uma configuração
        [HttpDelete("{id}")]
        public IActionResult DeleteConfiguracao(int id)
        {
            var sucesso = _configuracoesService.RemoverConfiguracao(id);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}
