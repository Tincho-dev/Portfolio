using Microsoft.JSInterop;
using Model;
using Radzen.Blazor.Rendering;

namespace Portfolio.Pages.Simulador;

public partial class Simulador
{
    public double IngresosEsperados { get; set; }
    public string Respuesta { get; set; } = String.Empty;
    public string Estado { get; set; } = "Esperando...";
    public string? AlertMessage { get; set; }
    public IEnumerable<DatoEspera> TiemposDeEspera { get; set; } = new List<DatoEspera>();
    IEnumerable<DatoEspera>? tiemposDeEsperaFiltrados;
    DateTime selectedDate = DateTime.Today;
    const double PrecioEntrada = 109;
    public double TiempoEsperaPromedio { get; set; }
    public double TiempoEsperaPromedioRR { get; set; }
    public double TiempoEsperaPromedioMF { get; set; }
    public double TiempoEsperaPromedioMensual { get; set; }
    public double TiempoEsperaPromedioRRMensual { get; set; }
    public double TiempoEsperaPromedioMFMensual { get; set; }
    public IEnumerable<DatoEspera> TiemposDeEsperaPromedioMensual { get; set; } = new List<DatoEspera>();


    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        OnDateChanged(selectedDate);
    }

    double GetTiempoPromedio(Atracciones name)
    {
        return tiemposDeEsperaFiltrados
        .FirstOrDefault(a => a.Nombre == name)?
        .TiempoEspera
        .Where(k => k.Key.Date == selectedDate.Date)
        .DefaultIfEmpty()
        .Average(t => t.Value) ?? 0;
    }

    public async Task OnDateChanged(DateTime? date)
    {
        if (date.HasValue)
        {
            selectedDate = date.Value;
            tiemposDeEsperaFiltrados = TiemposDeEspera.Where(d => d.TiempoEspera.Keys.Any(k => k.Date == selectedDate.Date));
            if (tiemposDeEsperaFiltrados.Any())
            {
                TiempoEsperaPromedioRR = tiemposDeEsperaFiltrados
                .FirstOrDefault(a => a.Nombre == Atracciones.RiseOfTheResistance)?
                .TiempoEspera
                .Where(k => k.Key.Date == selectedDate.Date)
                .DefaultIfEmpty()
                .Average(t => t.Value) ?? 0;


                TiempoEsperaPromedioMF = tiemposDeEsperaFiltrados
                .FirstOrDefault(a => a.Nombre == Atracciones.MilleniumFalcom)?
                .TiempoEspera
                .Where(k => k.Key.Date == selectedDate.Date)
                .DefaultIfEmpty()
                .Average(t => t.Value) ?? 0;
                TiempoEsperaPromedio = (TiempoEsperaPromedioMF + TiempoEsperaPromedioRR);
                await JSRuntime.InvokeVoidAsync("plotFunction", TiempoEsperaPromedio);
            }
        }
    }
   

    private async Task IngresosEsperadosChanged()
    {
        Estado = "Simulando...";
        AlertMessage = string.Empty;

        // Validación de los ingresos esperados.
        if (!ValidarIngresosEsperados())
        {
            return;
        }

        // Simulación y asignación de los resultados
        var simulacionResult = await SimulacionYAsignacionResultados();

        // Comprobación y manejo de los resultados
        Estado = string.IsNullOrEmpty(Respuesta)
        ? "Error: No se recibió respuesta"
        : "Simulacion completada.";


        // Actualización de la gráfica
        await JSRuntime.InvokeVoidAsync("plotFunction", TiempoEsperaPromedio);

        // Actualización de la fecha
        OnDateChanged(selectedDate);
    }

    private bool ValidarIngresosEsperados()
    {
        if (IngresosEsperados > 175 || IngresosEsperados < 0)
        {
            AlertMessage = "El ingreso esperado supera el límite. Por favor ingrese un valor menor.";
            Estado = "Error en la entrada.";
            return false;
        }

        return true;
    }

    private async Task<(string, IEnumerable<DatoEspera>, double)> SimulacionYAsignacionResultados()
    {
        var diasDelMes = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
        var simulacionResult = simulador.Simular((int)IngresosEsperados * 1000000, PrecioEntrada, diasDelMes);

        Respuesta = simulacionResult.Item1;
        TiemposDeEspera = simulacionResult.Item2;

        var tiempoEsperaRiseOfResistance = ObtenerTiempoEspera(Atracciones.RiseOfTheResistance);
        var tiempoEsperaMilleniumFalcom = ObtenerTiempoEspera(Atracciones.MilleniumFalcom);

        TiempoEsperaPromedioRRMensual = TiempoEsperaPromedioRR = tiempoEsperaRiseOfResistance;
        TiempoEsperaPromedioMFMensual = TiempoEsperaPromedioMF = tiempoEsperaMilleniumFalcom;
        TiempoEsperaPromedioMensual = TiempoEsperaPromedio = simulacionResult.Item3;

        return simulacionResult;
    }

    private double ObtenerTiempoEspera(Atracciones atraccion)
    {
        return TiemposDeEspera
            .FirstOrDefault(a => a.Nombre == atraccion)?
            .TiempoEspera
            .Where(t => t.Value > 0)
            .DefaultIfEmpty()
            .Average(t => t.Value) ?? 0;
    }


    private async Task HandleButtonMensualClick()
    {
        // Calcular el promedio mensual de los tiempos de espera para todas las atracciones
        TiempoEsperaPromedioRR = TiempoEsperaPromedioRRMensual;
        TiempoEsperaPromedioMF = TiempoEsperaPromedioMFMensual;
        TiempoEsperaPromedio = TiempoEsperaPromedioMensual;

        // Actualizar el gráfico con el nuevo promedio mensual
        await JSRuntime.InvokeVoidAsync("plotFunction", TiempoEsperaPromedio);
    }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("plotFunction");
        }
    }
}
