using Rosalind.Solutions;
using System;
using System.Diagnostics;

namespace Rosalind
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Stopwatch for time it takes to solve
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Insert code for execution here
            Console.WriteLine(LCSM.GetLongestCommonSubstring());

            // Stop timer and report time
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} ms", stopwatch.ElapsedMilliseconds);
        }
    }
}