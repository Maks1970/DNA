using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Linq;

namespace DNA
{
    internal class Program
    {


        public static List<KeyValuePair<char, int>> compress(string dna)
        {
            char A = 'A';
            char G = 'G';
            char C = 'C';
            char T = 'T';
            int k = 0;
            List<KeyValuePair<char, int>> dictionary = new List<KeyValuePair<char, int>>();

            for (int i = 0; i < dna.Length; i++)
            {

                if (dna[i] == A)
                {
                    for (; i < dna.Length; i++)
                    {
                        if (dna[i] == A)
                        {
                            k++;
                        }
                        else break;
                    }
                    //    while (i < dna.Length && dna[i] == A)
                    //{
                    //    i++;
                    //    k++;

                    //}
                    //i--;
                    dictionary.Add(new KeyValuePair<char, int>(A, k));
                    k = 0;
                    if (i >= dna.Length) break;
                }

                if (dna[i] == G)
                {
                    while (i < dna.Length && dna[i] == G)
                    {
                        i++;
                        k++;

                    }
                    i--;
                    dictionary.Add(new KeyValuePair<char, int>(G, k));
                    k = 0;
                    if (i >= dna.Length) break;
                }
                if (dna[i] == C)
                {
                    while (i < dna.Length && dna[i] == C)
                    {
                        i++;
                        k++;

                    }
                    i--;
                    dictionary.Add(new KeyValuePair<char, int>(C, k));
                    k = 0;
                    if (i >= dna.Length) break;
                }
                if (dna[i] == T)
                {
                    while (i < dna.Length && dna[i] == T)
                    {
                        i++;
                        k++;

                    }
                    i--;
                    dictionary.Add(new KeyValuePair<char, int>(T, k));
                    k = 0;
                    if (i >= dna.Length) break;
                }



            }
            return (dictionary);
        }


       public static List<char> decompress(string comdna)
        {
            List<char> list = new List<char>();
            char A = 'A';
            char G = 'G';
            char C = 'C';
            char T = 'T';
            int num = 0;
            int Numeric = 0;
            for (int i = 0; i < comdna.Length; i++)
            {
                
                if ((comdna[i] == A) )
                {
                         i++;
                         num = comdna[i];
                        if ((num <= 57) && (num > 48))
                        {
                            Numeric = num - '0';
                        }
                        for (int j = 0; j<Numeric; j++)
                        {
                            list.Add(A);
                        }
                       
                }

                if ((comdna[i] == G))
                {
                    i++;
                    num = comdna[i];
                    if ((num <= 57) && (num > 48))
                    {
                        Numeric = num - '0';
                    }
                    for (int j = 0; j < Numeric; j++)
                    {
                        list.Add(G);
                    }
                  
                }
                if ((comdna[i] == C))
                {
                    i++;
                    num = comdna[i];
                    if ((num <= 57) && (num > 48))
                    {
                        Numeric = num - '0';
                    }
                    for (int j = 0; j < Numeric; j++)
                    {
                        list.Add(C);
                    }

                }
                if ((comdna[i] == T))
                {
                    i++;
                    num = comdna[i];
                    if ((num <= 57) && (num > 48))
                    {
                        Numeric = num - '0';
                    }
                    for (int j = 0; j < Numeric; j++)
                    {
                        list.Add(T);
                    }

                }
            }
            return list;
        }
            static void Main(string[] args)
        {
            
            string dn = "AACCAGGGAAACCCTTTCCGGTTTTAAAA"; //
           // string ddn = "A2C2A1G3A3C3T3C2G2T4A4";
            dn = Console.ReadLine();
            int nu = dn[1];
            if ((nu <= 57) && (nu > 48))
            {
                List<Char> decom = new List<Char>();
                decom = decompress(dn);
                string result = string.Join("", decom);
                Console.WriteLine(result);
            }
            else 
            {
                List<KeyValuePair<char, int>> dic = new List<KeyValuePair<char, int>>();
                dic = compress(dn);
                foreach (KeyValuePair<char, int> kvp in dic)
                {
                    Console.Write($"{kvp.Key}{kvp.Value}");
                }
                Console.WriteLine();
            }
            
            
        }
    }
}
