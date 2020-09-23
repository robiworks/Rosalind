using System;
using System.IO;

namespace Rosalind.Solutions
{
    internal class REVC
    {
        public static string GetReverseComplement()
        {
            string sequenceDNA = File.ReadAllText(@"..\..\..\Datasets\rosalind_revc.txt");
            char[] s = sequenceDNA.ToCharArray();
            Array.Reverse(s);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A') { s[i] = 'T'; }
                else if (s[i] == 'T') { s[i] = 'A'; }
                else if (s[i] == 'C') { s[i] = 'G'; }
                else if (s[i] == 'G') { s[i] = 'C'; }
            }
            string output = new string(s);
            File.WriteAllText(@"..\..\..\Output\revc.txt", output);
            return output;
        }
    }
}