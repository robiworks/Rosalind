using System.IO;

namespace Rosalind.Solutions
{
    internal class HAMM
    {
        public static int GetHammingDistance()
        {
            string[] input = File.ReadAllLines(@"..\..\..\Datasets\rosalind_hamm.txt");
            int distance = 0;
            for (int i = 0; i < input[0].Length; i++)
            {
                if (input[0].Substring(i, 1) != input[1].Substring(i, 1))
                {
                    distance += 1;
                }
            }
            File.WriteAllText(@"..\..\..\Output\hamm.txt", distance.ToString());
            return distance;
        }
    }
}