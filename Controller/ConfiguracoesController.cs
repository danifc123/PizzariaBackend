using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfiguracoesController : ControllerBase
    {
        public static List<Configuracoes> Configuracoes = new List<Configuracoes>();

        [HttpGet]
        public IActionResult GetConfiguracoes()
        {
            return Ok(Configuracoes);
        }

        [HttpPost]
        public IActionResult AddConfiguracao(Configuracoes configuracao)
        {
            configuracao.Id = Configuracoes.Count + 1;
            Configuracoes.Add(configuracao);
            return CreatedAtAction(nameof(GetConfiguracaoById), new { id = configuracao.Id }, configuracao);
        }

        [HttpGet("{id}")]
        public IActionResult GetConfiguracaoById(int id)
        {
            var configuracao = Configuracoes.FirstOrDefault(c => c.Id == id);
            if (configuracao == null)
                return NotFound();

            return Ok(configuracao);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateConfiguracao(int id, Configuracoes configuracaoAtualizada)
        {
            var configuracao = Configuracoes.FirstOrDefault(c => c.Id == id);
            if (configuracao == null)
                return NotFound();

            configuracao.Nome = configuracaoAtualizada.Nome;
            configuracao.Valor = configuracaoAtualizada.Valor;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfiguracao(int id)
        {
            var configuracao = Configuracoes.FirstOrDefault(c => c.Id == id);
            if (configuracao == null)
                return NotFound();

            Configuracoes.Remove(configuracao);
            return NoContent();
        }
    }
}
