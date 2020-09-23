using System.Collections.Generic;
using System.IO;

namespace Rosalind.Solutions
{
    internal class PROT
    {
        public static string GetProteinString()
        {
            string input = File.ReadAllText(@"..\..\..\Datasets\rosalind_prot.txt");
            var codonTable = new Dictionary<string, string>()
            { {"UUU", "F" }, {"UUC", "F" }, {"UUA", "L" }, {"UUG", "L" }, {"UCU", "S" }, {"UCC", "S" }, {"UCA", "S" }, {"UCG", "S" },
                {"UAU", "Y" }, {"UAC", "Y" }, {"UGU", "C" }, {"UGC", "C" }, {"UGG", "W" }, {"CUU", "L" }, {"CUC", "L" }, {"CUA", "L" }, {"CUG", "L" },
                {"CCU", "P" }, {"CCC", "P" }, {"CCA", "P" }, {"CCG", "P" }, {"CAU", "H" }, {"CAC", "H" }, {"CAA", "Q" }, {"CAG", "Q" },
                {"CGU", "R" }, {"CGC", "R" }, {"CGA", "R" }, {"CGG", "R" }, {"AUU", "I" }, {"AUC", "I" }, {"AUA", "I" }, {"AUG", "M" },
                {"ACU", "T" }, {"ACC", "T" }, {"ACA", "T" }, {"ACG", "T" }, {"AAU", "N" }, {"AAC", "N" }, {"AAA", "K" }, {"AAG", "K" },
                {"AGU", "S" }, {"AGC", "S" }, {"AGA", "R" }, {"AGG", "R" }, {"GUU", "V" }, {"GUC", "V" }, {"GUA", "V"}, {"GUG", "V" },
                {"GCU", "A" }, {"GCC", "A" }, {"GCA", "A" }, {"GCG", "A" }, {"GAU", "D" }, {"GAC", "D" }, {"GAA", "E" }, {"GAG", "E" },
                {"GGU", "G" }, {"GGC", "G" }, {"GGA", "G" }, {"GGG", "G" }
            };
            string output = "";
            for (int i = 0; i < input.Length; i += 3)
            {
                string codon = input.Substring(i, 3);
                if ((codon == "UAA") || (codon == "UAG") || (codon == "UGA"))
                {
                    File.WriteAllText(@"..\..\..\Output\prot.txt", output);
                    return output;
                }
                else
                {
                    output += codonTable[codon];
                }
            }
            File.WriteAllText(@"..\..\..\Output\prot.txt", output);
            return output;
        }
    }
}