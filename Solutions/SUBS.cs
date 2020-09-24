using System.IO;

namespace Rosalind.Solutions
{
    internal class SUBS
    {
        public static string GetSubstringLocations()
        {
            string[] input = File.ReadAllLines(@"..\..\..\Datasets\rosalind_subs.txt");
            string s = input[0];
            string t = input[1];
            string output = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Substring(i).StartsWith(t))
                {
                    output += $"{i + 1} ";
                }
            }
            output = output.TrimEnd();
            File.WriteAllText(@"..\..\..\Output\subs.txt", output);
            return output;
        }
    }
}