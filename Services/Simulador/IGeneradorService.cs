namespace Services;

public interface IGeneradorService
{
    List<double> ParteCentralDelCuadrado(int digitosDeseados, int semilla, int totalDeNumerosaGenerar);
    List<double> Lehmer(int semilla, int constanteMultiplicativa, int totalDeNumerosaGenerar);
    List<double> CongruencialMixto(long semilla, long constanteAditiva, long constanteMultiplicativa,
       long modulo, int digitos, long totalDeNumerosaGenerar);
    double CongruencialMixto(long semilla, long constanteAditiva, long constanteMultiplicativa,
       long modulo, int digitos);
    List<double> CongruencialMultiplicativo(int semilla, int constanteMultiplicativa, int modulo, int totalDeNumerosaGenerar, int digitos);
    List<double> CongruencialAditivo(List<int> listaSemilla, int modulo, int totalDeNumerosaGenerar, int digitos);
}
