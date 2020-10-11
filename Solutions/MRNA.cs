using System.IO;
using System.Linq;

namespace Rosalind.Solutions
{
    internal class MRNA
    {
        public static string GetNumberOfPossibilities()
        {
            string input = File.ReadAllText(@"..\..\..\Datasets\rosalind_mrna.txt").Trim();
            var codonTable = Library.CodonTable;
            int result = 3; // To account for the stop codon, which means 3 protein possibilities
            for (int i = 0; i < input.Length; i++)
            {
                string protein = input.Substring(i, 1); // Take the translated protein
                int possibilities = codonTable.Count(p => p.Value == protein); // Count the number of occurrences in the RNA codon table
                result *= possibilities;
                if (result > 1000000)
                {
                    result %= 1000000; // Modulo 1000000 basically means only keeping the last 6 digits
                }
            }
            string output = result.ToString();
            File.WriteAllText(@"..\..\..\Output\mrna.txt", output);
            return output;
        }
    }
}