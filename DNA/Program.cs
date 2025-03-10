using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;

namespace DNA
{
    internal class Program
    {

        public static byte[] compress(string dna)
        {
            List<byte> compressed = new List<byte>();

            for (int i = 0; i < dna.Length; i += 4)
            {
                byte compressedByte = 0;

                for (int j = 0; j < 4 && i + j < dna.Length; j++)
                {
                    byte nucleotideBits = dna[i + j] switch
                    {
                        'A' => 0b00,
                        'C' => 0b01,
                        'G' => 0b10,
                        'T' => 0b11,
                        _ => throw new ArgumentException("Недійсний символ в ДНК-ланцюгу.")
                    };

                    compressedByte |= (byte)(nucleotideBits << (6 - 2 * j));
                }

                compressed.Add(compressedByte); 
            }

            return compressed.ToArray(); 
        }


        public static string DecompressDNA(byte[] compressedData)
        {
            StringBuilder decompressedDNA = new StringBuilder();

            foreach (byte compressedByte in compressedData)
            {
           
                for (int i = 0; i < 4; i++)
                {
                    
                    byte nucleotideBits = (byte)((compressedByte >> (6 - 2 * i)) & 0b11);
                 
                    char nucleotide = nucleotideBits switch
                    {
                        0b00 => 'A',
                        0b01 => 'C',
                        0b10 => 'G',
                        0b11 => 'T',
                        _ => throw new InvalidOperationException("Невідомий бітовий код")
                    };

                    decompressedDNA.Append(nucleotide);
                }
            }

            return decompressedDNA.ToString();
        }

        static void Main(string[] args)
        {
            
            string dn = "AACCAGGG"; 
            byte[] compres = compress(dn);
            Console.WriteLine("Стисненi данi: " + BitConverter.ToString(compres));
            Console.WriteLine("Данi: " + DecompressDNA(compres));


        }
    }
}
