using System.IO;
using System.Linq;

namespace Rosalind.Solutions
{
    internal class DNA
    {
        public static string CountNucleotides()
        {
            string sequenceDNA = File.ReadAllText(@"..\..\..\Datasets\rosalind_dna.txt");
            int a = sequenceDNA.Count(c => c == 'A');
            int t = sequenceDNA.Count(c => c == 'T');
            int c = sequenceDNA.Count(c => c == 'C');
            int g = sequenceDNA.Count(c => c == 'G');
            string output = $"{a} {c} {g} {t}";
            File.WriteAllText(@"..\..\..\Output\dna.txt", output);
            return output;
        }
    }
}