using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;
using PizzariaBackend.Services;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuponsController : ControllerBase
    {
        private readonly CuponsService _cuponsService;

        public CuponsController(CuponsService cuponsService)
        {
            _cuponsService = cuponsService;
        }

        // Get todos os cupons
        [HttpGet]
        public async Task<IActionResult> GetCupons()
        {
            var cupons = await _cuponsService.GetAllAsync();
            return Ok(cupons);
        }

        // Adicionar um novo cupom
        [HttpPost]
        public async Task<IActionResult> AddCupom(Cupom cupom)
        {
            await _cuponsService.AddAsync(cupom);
            return CreatedAtAction(nameof(GetCupomById), new { id = cupom.Id }, cupom);
        }

        // Buscar um cupom por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCupomById(int id)
        {
            var cupom = await _cuponsService.GetByIdAsync(id);
            if (cupom == null)
                return NotFound();

            return Ok(cupom);
        }

        // Atualizar um cupom
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCupom(int id, Cupom cupomAtualizado)
        {
            var cupomExistente = await _cuponsService.GetByIdAsync(id);
            if (cupomExistente == null)
                return NotFound();

            cupomExistente.Codigo = cupomAtualizado.Codigo;
            cupomExistente.Desconto = cupomAtualizado.Desconto;
            cupomExistente.Validade = cupomAtualizado.Validade;

            await _cuponsService.UpdateAsync(cupomExistente);
            return NoContent();
        }

        // Deletar um cupom
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCupom(int id)
        {
            var cupom = await _cuponsService.GetByIdAsync(id);
            if (cupom == null)
                return NotFound();

            await _cuponsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
