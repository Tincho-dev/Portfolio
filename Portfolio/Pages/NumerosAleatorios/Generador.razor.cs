namespace Portfolio.Pages.NumerosAleatorios;
public partial class Generador
{
    private int semilla;
    private int digitosDeseados;
    private int digitos;
    private int constanteMultiplicativa;
    private int constanteAditiva;
    private int modulo;
    private int totalDeNumerosGenerar;
    private string listaSemillaString;
    private List<double>? numerosGenerados;
    private List<string> metodosDisponibles = new List<string> { "ParteCentralDelCuadrado", "Lehmer", "CongruencialMixto", "CongruencialMultiplicativo", "CongruencialAditivo" };
    private string metodoSeleccionado;

    private void GenerarNumerosAleatorios()
    {
        numerosGenerados = metodoSeleccionado switch
        {
            "ParteCentralDelCuadrado" => GeneradorService.ParteCentralDelCuadrado(digitosDeseados, semilla, totalDeNumerosGenerar),
            "Lehmer" => GeneradorService.Lehmer(semilla, constanteMultiplicativa, totalDeNumerosGenerar),
            "CongruencialMixto" => GeneradorService.CongruencialMixto(semilla, constanteAditiva, constanteMultiplicativa, modulo, digitos, totalDeNumerosGenerar),
            "CongruencialMultiplicativo" => GeneradorService.CongruencialMultiplicativo(semilla, constanteMultiplicativa, modulo, totalDeNumerosGenerar, digitos),
            "CongruencialAditivo" => GeneradorService.CongruencialAditivo(ParseListaSemilla(listaSemillaString), modulo, totalDeNumerosGenerar, digitos),
            _ => null
        };
    }

    private List<int> ParseListaSemilla(string listaSemillaString)
    {
        List<int> listaSemilla = new List<int>();
        string[] numeros = listaSemillaString.Split(',');
        foreach (var numero in numeros)
        {
            if (int.TryParse(numero, out int parsedNumero))
            {
                listaSemilla.Add(parsedNumero);
            }
        }

        return listaSemilla;
    }
}
