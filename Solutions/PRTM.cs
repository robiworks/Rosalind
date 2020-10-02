using System.IO;

namespace Rosalind.Solutions
{
    internal class PRTM
    {
        public static string GetProteinMass()
        {
            string input = File.ReadAllText(@"..\..\..\Datasets\rosalind_prtm.txt");
            input = input.Trim();
            var massTable = Library.ParseMassTable();
            decimal proteinMass = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string protein = input.Substring(i, 1);
                proteinMass += massTable[protein];
            }
            string output = proteinMass.ToString().Replace(',', '.');
            File.WriteAllText(@"..\..\..\Output\prtm.txt", output);
            return output;
        }
    }
}