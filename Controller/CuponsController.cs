using Microsoft.AspNetCore.Mvc;
using PizzariaBackend.Models;

namespace PizzariaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuponsController : ControllerBase
    {
        public static List<Cupom> Cupons = new List<Cupom>();

        [HttpGet]
        public IActionResult GetCupons()
        {
            return Ok(Cupons);
        }

        [HttpPost]
        public IActionResult AddCupom(Cupom cupom)
        {
            cupom.Id = Cupons.Count + 1;
            Cupons.Add(cupom);
            return CreatedAtAction(nameof(GetCupomById), new { id = cupom.Id }, cupom);
        }

        [HttpGet("{id}")]
        public IActionResult GetCupomById(int id)
        {
            var cupom = Cupons.FirstOrDefault(c => c.Id == id);
            if (cupom == null)
                return NotFound();

            return Ok(cupom);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCupom(int id, Cupom cupomAtualizado)
        {
            var cupom = Cupons.FirstOrDefault(c => c.Id == id);
            if (cupom == null)
                return NotFound();

            cupom.Codigo = cupomAtualizado.Codigo;
            cupom.Desconto = cupomAtualizado.Desconto;
            cupom.Validade = cupomAtualizado.Validade;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCupom(int id)
        {
            var cupom = Cupons.FirstOrDefault(c => c.Id == id);
            if (cupom == null)
                return NotFound();

            Cupons.Remove(cupom);
            return NoContent();
        }
    }
}
