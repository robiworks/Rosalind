using System.IO;
using System.Linq;

namespace Rosalind.Solutions
{
    internal class FIBD
    {
        public static string GetNumberOfPairs()
        {
            string input = File.ReadAllText(@"..\..\..\Datasets\rosalind_fibd.txt");
            long n = long.Parse(input.Split(' ')[0]); // number of months
            long m = long.Parse(input.Split(' ')[1]); // number of months that rabbits live
            long[] pairs = new long[m]; // index 0 is for newborns
            pairs[1] = 1;
            for (int i = 3; i <= n; i++)
            {
                long adults = 0;
                for (int k = 1; k < pairs.Length; k++) // get number of adults currently living
                {
                    adults += pairs[k];
                }
                for (int j = pairs.Length - 1; j > 0; j--) // shift older rabbits to the right
                {
                    pairs[j] = pairs[j - 1];
                }
                pairs[0] = adults;
            }
            string output = pairs.Sum().ToString();
            File.WriteAllText(@"..\..\..\Output\fibd.txt", output);
            return output;
        }
    }
}