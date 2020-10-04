using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Rosalind
{
    internal class Library // Library of common functions
    {
        public static string[] ParseFastaToArray(string[] inputFile) // Parse FASTA format without sequence identifiers
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

        public static Dictionary<string, string> ParseFastaToDictionary(string[] inputFile) // Parse FASTA format with sequence identifiers
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

        public static string[] UniprotDownload(string uniprotID) // Downloads protein data from the UniProt Database in FASTA format
        {
            Uri url = new Uri("http://www.uniprot.org/uniprot/" + uniprotID + ".fasta");
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, @"..\..\..\Datasets\uniprot_dw.txt");
            }
            string[] contents = File.ReadAllLines(@"..\..\..\Datasets\uniprot_dw.txt");
            contents[0] = ">" + uniprotID;
            return contents;
        }

        public static Dictionary<string, decimal> ParseMassTable()
        {
            string[] inputFile = File.ReadAllLines(@"..\..\..\Datasets\monoisotopicMassTable.txt");
            var dict = new Dictionary<string, decimal>();
            for (int i = 0; i < inputFile.Length; i++)
            {
                string protein = inputFile[i].Substring(0, 1);
                decimal mass = decimal.Parse(inputFile[i].Substring(4).Replace('.', ','));
                dict.Add(protein, mass);
            }
            dict.Add("WATER", (decimal)18.01056);
            return dict;
        }

        public static int IntFactorial(int number)
        {
            for (int i = 2; i <= number; i++)
            {
                number *= i;
            }
            return number;
        }
    }
}