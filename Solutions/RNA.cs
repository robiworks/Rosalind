using System.IO;

namespace Rosalind.Solutions
{
    internal class RNA
    {
        public static string TranscribeDNAtoRNA()
        {
            string sequenceDNA = File.ReadAllText(@"..\..\..\Datasets\rosalind_rna.txt");
            string output = sequenceDNA.Replace('T', 'U');
            File.WriteAllText(@"..\..\..\Output\rna.txt", output);
            return output;
        }
    }
}