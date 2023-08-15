﻿using System.Collections;

namespace Model;

public class HuffmanTree
{
    private List<Node> nodes = new List<Node>();
    public Node Root { get; set; }
    public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

    public void Build(string source)
    {
        for (int i = 0; i < source.Length; i++)
        {
            if (!Frequencies.ContainsKey(source[i]))
            {
                Frequencies.Add(source[i], 0);
            }

            Frequencies[source[i]]++;
        }
        foreach (KeyValuePair<char, int> symbol in Frequencies)
        {
            nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
        }

        while (nodes.Count > 1)
        {
            List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();
            if (orderedNodes.Count >= 2)
            {
                List<Node> taken = orderedNodes.Take(2).ToList<Node>();

                Node parent = new Node()
                {
                    Symbol = '*',
                    Frequency = taken[0].Frequency + taken[1].Frequency,
                    Left = taken[0],
                    Right = taken[1]
                };

                nodes.Remove(taken[0]);
                nodes.Remove(taken[1]);
                nodes.Add(parent);
            }
        }
        this.Root = nodes.FirstOrDefault();

    }
    public List<Letra> Encode(List<Letra> source)
    {
        for (int i = 0; i < source.Count; i++)
        {
            List<bool> encodedSymbol = this.Root.Traverse(source[i].Name.First(), new List<bool>());
            string codigo = "";
            encodedSymbol.ForEach(b => codigo += Convert.ToInt32(b));
            string nombre = source[i].ToString();
            source[i].Code = codigo;
        }
        return source;
    }

    public string Decode(BitArray bits)
    {
        Node current = this.Root;
        string decoded = "";

        foreach (bool bit in bits)
        {
            if (bit)
            {
                if (current.Right != null)
                {
                    current = current.Right;
                }
            }
            else
            {
                if (current.Left != null)
                {
                    current = current.Left;
                }
            }

            if (IsLeaf(current))
            {
                decoded += current.Symbol;
                current = this.Root;
            }
        }
        return decoded;
    }

    public bool IsLeaf(Node node)
    {
        return (node.Left == null && node.Right == null);
    }
}
