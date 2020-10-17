using System.Collections.Generic;
using System.IO;

namespace Rosalind.Solutions
{
    internal class PERM
    {
        // List for storing number of permutations and all permutations
        public static List<string> permutations = new List<string>();

        public static string GetPermutations()
        {
            // Read input from file
            string input = File.ReadAllText(@"..\..\..\Datasets\rosalind_perm.txt");
            int number = int.Parse(input);

            // Generate initial array from input number
            int[] array = new int[number];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            // Total number of permutations is factorial of number
            int totalNumber = Library.IntFactorial(number);
            permutations.Add(totalNumber.ToString());

            // Start permuting
            Permute(array);

            // Write output to file
            string[] output = permutations.ToArray();
            File.WriteAllLines(@"..\..\..\Output\perm.txt", output);
            return @"Output written to Output\perm.txt";
        }

        private static void Permute(int[] arr)
        {
            PermuteHelper(arr, 0);
        }

        private static void PermuteHelper(int[] array, int index)
        {
            if (index >= array.Length - 1)
            {
                string permutation = "";
                for (int i = 0; i < array.Length - 1; i++)
                {
                    permutation += $"{array[i]} ";
                }
                if (array.Length > 0)
                {
                    permutation += $"{array[array.Length - 1]}";
                }
                permutation = permutation.Trim();
                permutations.Add(new string(permutation));
                return;
            }

            for (int i = index; i < array.Length; i++)
            {
                // Swap
                int temp = array[index];
                array[index] = array[i];
                array[i] = temp;

                PermuteHelper(array, index + 1);

                // Swap again
                temp = array[index];
                array[index] = array[i];
                array[i] = temp;
            }
        }
    }
}