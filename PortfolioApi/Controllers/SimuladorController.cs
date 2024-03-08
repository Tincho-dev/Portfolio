using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimuladorController : ControllerBase
    {
        private readonly Services.ISimuladorColasEsperaService _simuladorService;

        public SimuladorController(ISimuladorColasEsperaService simuladorService)
        {
            _simuladorService = simuladorService;
        }
        //int TiempoEspera(int visitantes, double tiempoServicio, int capacidad);
        //(string, IEnumerable<DatoEspera>, double) Simular(int ingresoEsperado, double precioEntrada, int diasDelMes);
        [HttpGet("simular")]
        public IActionResult Simular(int ingresoEsperado = 90, double precioEntrada = 120, int diasDelMes = 30)
        {
            var result = _simuladorService.Simular(ingresoEsperado, precioEntrada, diasDelMes);
            return Ok(result);
        }

        //IEnumerable<DatoEspera> GetDatoEsperas();
        [HttpGet("datoEsperas")]
        public IActionResult GetDatoEsperas()
        {
            var result = _simuladorService.GetDatoEsperas();
            return Ok(result);
        }
    }
}
