using Microsoft.AspNetCore.Mvc;
using MoradorBairroAPI.Models;
using MoradorBairroAPI.Models.DTO;
using MoradorBairroAPI.Services;

namespace MoradorBairroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoradoresController : ControllerBase
    {
        private readonly MoradorService _moradorService;
        private readonly BairroService _bairroService;

        public MoradoresController(MoradorService moradorService, BairroService bairroService)
        {
            _moradorService = moradorService;
            _bairroService = bairroService;
        }

        [HttpGet]
        public ActionResult<List<Morador>> Get() =>
            _moradorService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Morador> Get(string id)
        {
            var morador = _moradorService.Get(id);
            if (morador == null)
                return NotFound();
            return morador;
        }

        [HttpPost]
        public ActionResult<Morador> Create(MoradorCreateDto moradorDto)
        {
            var morador = new Morador
            {
                Nome = moradorDto.Nome,
                Idade = moradorDto.Idade,
                BairroId = moradorDto.BairroId
            };

            _moradorService.Create(morador);
            return CreatedAtAction(nameof(Get), new { id = morador.Id }, morador);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Morador moradorIn)
        {
            var morador = _moradorService.Get(id);
            if (morador == null)
                return NotFound();

            _moradorService.Update(id, moradorIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var morador = _moradorService.Get(id);
            if (morador == null)
                return NotFound();

            _moradorService.Remove(id);
            return NoContent();
        }

        // ✅ Nova rota: moradores com nome e zona do bairro
        [HttpGet("com-bairro")]
        public ActionResult<List<MoradorComBairro>> GetComBairro()
        {
            var moradores = _moradorService.Get();
            var bairros = _bairroService.Get();

            var resultado = moradores.Select(m =>
            {
                var bairro = bairros.FirstOrDefault(b => b.Id == m.BairroId);

                return new MoradorComBairro
                {
                    Id = m.Id,
                    Nome = m.Nome,
                    Idade = m.Idade,
                    BairroId = m.BairroId,
                    BairroNome = bairro?.Nome ?? "Desconhecido",
                    BairroZona = bairro?.Zona ?? "Desconhecida"
                };
            }).ToList();

            return Ok(resultado);
        }
    }
}
