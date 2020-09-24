using System;
using System.IO;
using System.Linq;

namespace Rosalind.Solutions
{
    internal class CONS
    {
        public static string GetConsensusAndProfile()
        {
            string[] input = File.ReadAllLines(@"..\..\..\Datasets\rosalind_cons.txt");
            string[] data = new string[input.Count(s => s.StartsWith(">"))];
            // Parse input without FASTA codes as they are not needed
            int j = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith(">"))
                {
                    j++;
                }
                else
                {
                    data[j] += input[i];
                }
            }
            // Frequency analysis to get base profile and generate consensus string
            string consensus = "";
            string[] output = new string[5] { "", "A: ", "C: ", "G: ", "T: " };
            for (int col = 0; col < data[0].Length; col++)
            {
                int[] freq = new int[4] { 0, 0, 0, 0 };
                for (int row = 0; row < data.Length; row++)
                {
                    switch (data[row].Substring(col, 1))
                    {
                        case "A":
                            freq[0]++;
                            break;

                        case "C":
                            freq[1]++;
                            break;

                        case "G":
                            freq[2]++;
                            break;

                        case "T":
                            freq[3]++;
                            break;

                        default:
                            return "Invalid letter found, check input/code";
                    }
                }
                output[1] += freq[0].ToString() + " "; // A
                output[2] += freq[1].ToString() + " "; // C
                output[3] += freq[2].ToString() + " "; // G
                output[4] += freq[3].ToString() + " "; // T
                int m = freq.Max();
                switch (Array.IndexOf(freq, m))
                {
                    case 0:
                        consensus += "A";
                        break;

                    case 1:
                        consensus += "C";
                        break;

                    case 2:
                        consensus += "G";
                        break;

                    case 3:
                        consensus += "T";
                        break;

                    default:
                        return "Something went wrong when generating consensus string, check code...";
                }
            }
            output[0] = consensus;
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = output[i].TrimEnd();
            }
            File.WriteAllLines(@"..\..\..\Output\cons.txt", output);
            return @"Output written to Output\cons.txt";
        }
    }
}