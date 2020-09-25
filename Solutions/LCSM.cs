using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Solutions
{
    internal class LCSM
    {
        // Solution from stackoverflow as I had no idea myself, but now I understand the concept :)
        // https://stackoverflow.com/questions/18953208/find-longest-substring-in-an-array-of-strings-and-remove-it-from-all-the-element
        // The solution takes quite a bit of time tho (23s on my 2020 laptop); will eventually implement the solution from the Rosalind explanation.

        public static string GetLongestCommonSubstring()
        {
            string[] input = File.ReadAllLines(@"..\..\..\Datasets\rosalind_lcsm.txt");
            string[] data = Library.ParseFastaToArray(input);

            var commonSubstrings = new HashSet<string>(GetSubstrings(data[0]));
            foreach (string str in data.Skip(1))
            {
                commonSubstrings.IntersectWith(GetSubstrings(str));
                if (commonSubstrings.Count == 0)
                {
                    return null;
                }
            }
            string output = commonSubstrings.OrderByDescending(s => s.Length).First();
            File.WriteAllText(@"..\..\..\Output\lcsm.txt", output);
            return output;
        }

        public static IEnumerable<string> GetSubstrings(string str)
        {
            for (int c = 0; c < str.Length - 1; c++)
            {
                for (int cc = 1; c + cc <= str.Length; cc++)
                {
                    yield return str.Substring(c, cc);
                }
            }
        }
    }
}