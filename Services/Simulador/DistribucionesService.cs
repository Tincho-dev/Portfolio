using System.Security.Cryptography;

namespace Services;

public class DistribucionesService : IDistribucionesService
{
    private readonly IGeneradorService GeneradorService;
    private long Semilla;
    private readonly long ConstanteAditiva,
        ConstanteMultiplicativa, Modulo;
    private readonly int Digitos;

    public DistribucionesService(IGeneradorService generadorService)
    {
        GeneradorService = generadorService;
        Semilla = 1;
        ConstanteAditiva = 123456;
        ConstanteMultiplicativa = 1103515245;
        Modulo = 2147483648;
        Digitos = 2;
    }

    public double GenerarNumeroAleatorio()
    => GeneradorService.CongruencialMixto(
        Semilla++,
        ConstanteAditiva,
        ConstanteMultiplicativa,
        Modulo,
        Digitos);
}
