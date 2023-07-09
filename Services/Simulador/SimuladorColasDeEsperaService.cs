using Model;

namespace Services
{
    public class SimuladorColasEsperaService : ISimuladorColasEsperaService
    {
        private readonly IDistribucionesService _distribucionesService;
        private double _u;
        public List<DatoEspera> TiemposPorAtraccion { get; private set; }

        public SimuladorColasEsperaService(IDistribucionesService distribucionesService)
        {
            _distribucionesService = distribucionesService;
            TiemposPorAtraccion = new List<DatoEspera>();
        }

        public (string, IEnumerable<DatoEspera>, double) Simular(int ingresoEsperado, double precioEntrada)
        {
            TiemposPorAtraccion = SimularTiemposDeEspera(ingresoEsperado, precioEntrada);
            double tiempoEsperaPromedio = TiemposPorAtraccion.Where(d => d.TiempoEspera != null)
                                                              .SelectMany(d => d.TiempoEspera?.Values)
                                                              .DefaultIfEmpty()
                                                              .Average();
            var respuesta = GetRespuesta(tiempoEsperaPromedio);
            return (respuesta, TiemposPorAtraccion, tiempoEsperaPromedio);
        }

        public IEnumerable<DatoEspera> GetDatoEsperas() => TiemposPorAtraccion;

        public List<DatoEspera> SimularTiemposDeEspera(int ingresoEsperado, double precioEntrada)
        {
            var precio = precioEntrada;
            var tiempoServicioRR = 18;
            var tiempoServicioMF = 4.5;
            var capacidadRR = 60;
            var capacidadMF = 42;

            var cantidadVisitantesMensuales = ingresoEsperado / precio;
            var cantidadVisitantesDiariosPromedio = cantidadVisitantesMensuales / 30;
            var cantidadVisitantesPorHoraPromedio = cantidadVisitantesDiariosPromedio / 16;

            var datosEsperaRR = new DatoEspera { Nombre = Atracciones.RiseOfTheResistance, TiempoEspera = new Dictionary<DateTime, double>() };
            var datosEsperaMF = new DatoEspera { Nombre = Atracciones.MilleniumFalcom, TiempoEspera = new Dictionary<DateTime, double>() };

            int visitantesRR, visitantesMF;

            for (int dia = 0; dia <= 30; dia++)
            {
                for (int hora = 0; hora <= 16; hora++)
                {
                    visitantesRR = visitantesMF = 0;
                    _u = _distribucionesService.GenerarNumeroAleatorio();
                    int visitantesPorHora = (int)(-cantidadVisitantesPorHoraPromedio * Math.Log(_u));

                    for (int visitantes = 0; visitantes < visitantesPorHora; visitantes++)
                    {
                        _u = _distribucionesService.GenerarNumeroAleatorio();
                        if (_u <= 0.75)
                        {
                            _u = _distribucionesService.GenerarNumeroAleatorio();
                            if (_u <= 0.3)
                            {
                                visitantesRR++;
                            }
                            else
                            {
                                visitantesMF++;
                            }
                        }
                    }
                    // tiempo de espera de cada hora de cada día
                    datosEsperaRR.TiempoEspera.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, dia + 1, hora, 0, 0), TiempoEspera(visitantesRR, tiempoServicioRR, capacidadRR));
                    datosEsperaMF.TiempoEspera.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, dia + 1, hora, 0, 0), TiempoEspera(visitantesMF, tiempoServicioMF, capacidadMF));
                }
            }
            return new List<DatoEspera> { datosEsperaRR, datosEsperaMF };
        }

        public int TiempoEspera(int visitantes, double tiempoServicio, int capacidad)
        => (int)(visitantes / capacidad * tiempoServicio);

        private string GetRespuesta(double tiempoEsperaPromedio) =>
        tiempoEsperaPromedio switch
        {
            <= 130 => @"Cumple con el ingreso esperado y los clientes estan satisfechos con los tiempos de espera",
            <= 180 => @"Cumple con el ingreso esperado y los tiempos de espera son razonables (estan entre los registradosEn el pasado)",
            <= 360 => @"La gente esta inconforme con el amontonamiento y los altos tiempos de espera",
            _ => @"La capacidad del establecimiento es insuficiente para lograr el ingreso esperado"
        };
    }
}
