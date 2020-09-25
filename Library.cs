using System.Collections.Generic;
using System.Linq;

namespace Rosalind
{
    internal class Library // library of common functions
    {
        public static string[] ParseFastaToArray(string[] inputFile) // parse FASTA format without sequence identifiers
        {
            string[] arr = new string[inputFile.Count(s => s.StartsWith('>'))];
            int n = -1;
            for (int i = 0; i < inputFile.Length; i++)
            {
                if (inputFile[i].StartsWith('>'))
                {
                    n++;
                }
                else
                {
                    arr[n] += inputFile[i];
                }
            }
            return arr;
        }

        public static Dictionary<string, string> ParseFastaToDictionary(string[] inputFile) // parse FASTA format with sequence identifiers
        {
            var dict = new Dictionary<string, string>();
            string identifier = "";
            for (int i = 0; i < inputFile.Length; i++)
            {
                if (inputFile[i].StartsWith('>'))
                {
                    identifier = inputFile[i].Substring(1);
                    dict.Add(identifier, "");
                }
                else
                {
                    dict[identifier] += inputFile[i];
                }
            }
            return dict;
        }
    }
}