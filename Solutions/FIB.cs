using System;
using System.IO;

namespace Rosalind.Solutions
{
    internal class FIB
    {
        public static string GetNumberOfPairs()
        {
            string input = File.ReadAllText(@"..\..\..\Datasets\rosalind_fib.txt");
            long[] arr = Array.ConvertAll(input.Split(' '), long.Parse);
            long n = arr[0]; // number of months
            long k = arr[1]; // reproduction factor
            long pairs = 0;
            long[] newborns = { 1, 0 };
            for (int i = 2; i <= n; i++)
            {
                newborns[1] = pairs * k;
                pairs += newborns[0];
                newborns[0] = newborns[1];
            }
            string output = (pairs + newborns[0]).ToString();
            File.WriteAllText(@"..\..\..\Output\fib.txt", output);
            return output;
        }
    }
}