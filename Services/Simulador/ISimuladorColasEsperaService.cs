using Model;

namespace Services;

public interface ISimuladorColasEsperaService
{
    int TiempoEspera(int visitantes, double tiempoServicio, int capacidad);
    (string, IEnumerable<DatoEspera>, double) Simular(int ingresoEsperado, double precioEntrada, int diasDelMes);
    IEnumerable<DatoEspera> GetDatoEsperas();
}
