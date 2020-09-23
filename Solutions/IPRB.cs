using System.IO;

namespace Rosalind.Solutions
{
    internal class IPRB
    {
        public static string GetDominantProbability()
        {
            string input = File.ReadAllText(@"..\..\..\Datasets\rosalind_iprb.txt");
            string[] arr = input.Split(' ');
            double k = double.Parse(arr[0]); // AA homozygous dominant
            double m = double.Parse(arr[1]); // Aa heterozygous
            double n = double.Parse(arr[2]); // aa homozygous recessive
            double population = k + m + n;

            double k1k2 = k / population; // k + k mating (100%)
            double k1m2 = (k / population) * (m / (population - 1)); // k + m mating (100%)
            double k1n2 = (k / population) * (n / (population - 1)); // k + n mating (100%)
            double m1m2 = (m / population) * ((m - 1) / (population - 1)) * 0.75; // m + m mating (75%)
            double m1n2 = (m / population) * (n / (population - 1)) * 0.5; // m + n mating (50%)
            double n1m2 = (n / population) * (m / (population - 1)) * 0.5; // n + m mating (50%)

            double probability = k1k2 + k1m2 + k1n2 + m1m2 + m1n2 + n1m2;
            string output = probability.ToString().Replace(',', '.');
            File.WriteAllText(@"..\..\..\Output\iprb.txt", output);
            return output;
        }
    }
}