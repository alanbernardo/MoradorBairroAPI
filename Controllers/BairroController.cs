using Microsoft.AspNetCore.Mvc;
using MoradorBairroAPI.Models;
using MoradorBairroAPI.Services;

namespace MoradorBairroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BairrosController : ControllerBase
    {
        private readonly BairroService _bairroService;

        public BairrosController(BairroService bairroService)
        {
            _bairroService = bairroService;
        }

        [HttpGet]
        public ActionResult<List<Bairro>> Get() => _bairroService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Bairro> Get(string id)
        {
            var bairro = _bairroService.Get(id);
            if (bairro == null)
                return NotFound();
            return bairro;
        }

        [HttpPost]
        public ActionResult<Bairro> Create(Bairro bairro)
        {
            _bairroService.Create(bairro);
            return CreatedAtAction(nameof(Get), new { id = bairro.Id }, bairro);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Bairro bairroIn)
        {
            var bairro = _bairroService.Get(id);
            if (bairro == null)
                return NotFound();

            _bairroService.Update(id, bairroIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var bairro = _bairroService.Get(id);
            if (bairro == null)
                return NotFound();

            _bairroService.Remove(id);
            return NoContent();
        }
    }
}
