using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rosalind.Solutions
{
    internal class GC
    {
        public static string GetGCContent()
        {
            string[] input = File.ReadAllLines(@"..\..\..\Datasets\rosalind_gc.txt");
            var data = new Dictionary<string, string>();
            string id = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith(">"))
                {
                    id = input[i].Substring(1);
                    data.Add(id, "");
                }
                else
                {
                    data[id] += input[i];
                }
            }
            double content = 0;
            string identifier = "";
            foreach (var item in data)
            {
                string sequence = item.Value;
                char[] arr = sequence.ToCharArray();
                int count = arr.Count(c => c == 'G' || c == 'C');
                double ratio = (double)count / (double)sequence.Length;
                if (ratio >= content)
                {
                    content = ratio;
                    identifier = item.Key;
                }
            }
            string[] output = { identifier, (content * 100).ToString().Replace(',', '.') };
            File.WriteAllLines(@"..\..\..\Output\gc.txt", output);
            return @"Output written to Output\gc.txt";
        }
    }
}