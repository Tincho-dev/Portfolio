using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Fuente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string IdFuente { get; set; }
    [Required]
    public List<Letra> Letras { get; set; } = new List<Letra>();
    [Display(Name = "Cadena usada para generar la fuente: ")]
    public string CadenaFuente { get; set; } = "";

    #region Constructor
    public Fuente()
    {
        IdFuente = Guid.NewGuid().ToString();
    }

    public Fuente(string cadena)
    {
        if (cadena == null) CadenaFuente = "";
        CadenaFuente = cadena;
        Letras = StringToListLetra();
        EstablecerCodigoHuffmanACadaLetra();
    }
    #endregion
    #region Entropia
    public float EntropiaDeLaFuente() =>
        Letras.Sum(letra => letra.Probability * (float)(Math.Log(1 / letra.Probability) / Math.Log(2)));

    public float EntropiaMaxima() => 
        (float)(Math.Log10(Letras.Count) / Math.Log10(2));

    public float InformacionDeCadena() => 
        (float) Letras.Sum(letra => (Math.Log(1 / letra.Probability) / Math.Log(2)));


    public List<Letra> StringToListLetra()
    {
        List<Letra> listaDeLetras = new();
        if (CadenaFuente != null)
        {
            char[] caracteres = CadenaFuente.ToCharArray();
            int total = caracteres.Length;
            char[] letrasDistintas = caracteres.Distinct().ToArray();
            foreach (char item in letrasDistintas)
            {
                int freq = caracteres.Count(f => (f == item));
                double probabilidad = (double)freq / total;
                Letra letraAgregar = new Letra(item.ToString(), probabilidad, freq);
                letraAgregar.Id = letraAgregar.GetHashCode().ToString();
                listaDeLetras.Add(letraAgregar);
            }
        }
        return listaDeLetras;
    }
    #endregion
    #region Codificacion
    public string CodificarCadena()
    {
        string codigoFinal = "";
        foreach (var simbolo in CadenaFuente)
        {
            var codigo = (from l in Letras
                          where (l.Name == simbolo.ToString())
                          select l.Code).Single();
            codigoFinal += codigo.ToString();
        }
        return codigoFinal;
    }

    public void EstablecerCodigoACadaLetra()
    {
        Letras = Letras.OrderByDescending(l => l.Probability).ToList();
        var LetrasArray = Letras.ToArray();

        for (int i = 0; i < LetrasArray.Length; i++)
        {
            LetrasArray[i].Code = Convert.ToString(i, 2);
        }
        Letras = LetrasArray.ToList();
    }
    #endregion
    #region Codificacion Huffman
    public void EstablecerCodigoHuffmanACadaLetra()
    {
        HuffmanTree huffmanTree = new HuffmanTree();
        huffmanTree.Build(CadenaFuente);
        Letras = huffmanTree.Encode(Letras);
    }

    public string DecodificarHuffman()
    {
        HuffmanTree huffmanTree = new HuffmanTree();
        huffmanTree.Build(CadenaFuente);
        var CadenaCodificada = CodificarCadena();
        var res = new BitArray(CadenaCodificada.Select(c => c == '1').ToArray());
        BitArray bits = new BitArray(res);

        return huffmanTree.Decode(res);
    }

    public string DecodificarHuffman(string cadena)
    {
        HuffmanTree huffmanTree = new HuffmanTree();
        huffmanTree.Build(CadenaFuente);
        var res = new BitArray(cadena.Select(c => c == '1').ToArray());
        BitArray bits = new BitArray(res);

        return huffmanTree.Decode(res);
    }
    #endregion
}
