using System;
using System.IO;

namespace Rosalind.Solutions
{
    internal class IEV
    {
        public static string GetNumberOfDominantOffspring()
        {
            string input = File.ReadAllText(@"..\..\..\Datasets\rosalind_iev.txt");
            double[] population = Array.ConvertAll<string, double>(input.Split(' '), double.Parse);

            // Probabilities of first 3 genotypes are 100%
            double gen1 = population[0] * 2; // AA - AA
            double gen2 = population[1] * 2; // AA - Aa
            double gen3 = population[2] * 2; // AA - aa
            // Probabilities of second 3 genotypes are 75%, 50% and 0%
            double gen4 = (population[3] * 2) * 0.75; // Aa - Aa
            double gen5 = (population[4] * 2) * 0.5; // Aa - aa
            double expectedValue = gen1 + gen2 + gen3 + gen4 + gen5;

            string output = expectedValue.ToString().Replace(',', '.');
            File.WriteAllText(@"..\..\..\Output\iev.txt", output);
            return output;
        }
    }
}