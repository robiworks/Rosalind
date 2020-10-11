using System.Collections.Generic;
using System.IO;

namespace Rosalind.Solutions
{
    internal class REVP
    {
        public static string GetReversePalindromes()
        {
            string[] input = File.ReadAllLines(@"..\..\..\Datasets\rosalind_revp.txt");
            string dna = Library.ParseFastaToArray(input)[0];
            List<string> palindromes = new List<string>();

            // Start scanning through the DNA sequence
            for (int i = 0; i < dna.Length - 3; i++)
            {
                // Scan lengths 4 to 12
                for (int len = 4; len <= 12; len++)
                {
                    // Scan only if the subsequence would be inside the DNA sequence
                    if (i + len <= dna.Length)
                    {
                        string pattern1 = dna.Substring(i, len);
                        string pattern2 = Library.GetReverseComplement(pattern1);
                        if (pattern1 == pattern2)
                        {
                            string match = $"{i + 1} {len}";
                            palindromes.Add(match);
                        }
                    }
                }
            }

            // Write output to file
            string[] output = palindromes.ToArray();
            File.WriteAllLines(@"..\..\..\Output\revp.txt", output);
            return @"Output written to Output\revp.txt";
        }
    }
}