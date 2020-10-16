using System.IO;

namespace Rosalind.Solutions
{
    internal class SPLC
    {
        public static string GetProteinString()
        {
            string[] input = File.ReadAllLines(@"..\..\..\Datasets\rosalind_splc.txt");
            string[] arr = Library.ParseFastaToArray(input);
            string output = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                output = output.Replace(arr[i], "");
            }
            output = Library.TranscribeDNAtoRNA(output);

            var codonTable = Library.RnaCodonTable;
            string protein = "";
            for (int i = 0; i < output.Length; i += 3)
            {
                string codon = output.Substring(i, 3);
                if ((codon == "UAA") || (codon == "UAG") || (codon == "UGA"))
                {
                    File.WriteAllText(@"..\..\..\Output\splc.txt", protein);
                    return protein;
                }
                else
                {
                    protein += codonTable[codon];
                }
            }
            File.WriteAllText(@"..\..\..\Output\splc.txt", output);
            return output;
        }
    }
}