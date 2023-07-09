namespace Model;

public class DatoEspera
{
    public Atracciones Nombre { get; set; } // El nombre de la atracción
    public Dictionary<DateTime, double>? TiempoEspera { get; set; } // El tiempo de espera en minutos asociado a cada fecha y hora
}

public enum Atracciones
{
    RiseOfTheResistance,
    MilleniumFalcom
}
