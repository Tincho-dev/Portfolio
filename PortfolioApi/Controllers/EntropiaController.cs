using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntropiaController : ControllerBase
    {
        private IFuenteService _fuenteService;

        public EntropiaController(IFuenteService fuenteService)
        {
            _fuenteService = fuenteService;
        }

        //List<Fuente> Fuentes { get; }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (_fuenteService.Fuentes.Count == 0)
            await _fuenteService.Load();

            return Ok(_fuenteService.Fuentes);
        }

        //Task<Fuente> GetSingle(string id);
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            if (_fuenteService.Fuentes.Count == 0)
                await _fuenteService.Load();

            var result = await _fuenteService.GetSingle(id);
            return Ok(result);
        }

        //Task Update(Fuente fuente, string id);
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Fuente fuente, string id)
        {
            await _fuenteService.Update(fuente, id);
            return Ok();
        }

        //Task Create(Fuente fuente);
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Fuente fuente)
        {
            await _fuenteService.Create(fuente);
            return Ok();
        }

        //Task Delete(string id);
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _fuenteService.Delete(id);
            return Ok();
        }
    }
}
