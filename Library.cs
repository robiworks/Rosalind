using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Rosalind
{
    /// <summary>
    /// Library of common functions for use in Rosalind problems.
    /// </summary>
    internal class Library
    {
        /// <summary>
        /// Parses FASTA format without sequence identifiers.
        /// </summary>
        /// <param name="inputFile">A string array in FASTA format.</param>
        /// <returns>An array of parsed genetic strings.</returns>
        public static string[] ParseFastaToArray(string[] inputFile)
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

        /// <summary>
        /// Parses FASTA format with sequence identifiers.
        /// </summary>
        /// <param name="inputFile">A string array in FASTA format.</param>
        /// <returns>A dictionary of parsed genetic strings with identifiers as keys.</returns>
        public static Dictionary<string, string> ParseFastaToDictionary(string[] inputFile)
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

        /// <summary>
        /// RNA codon table. Stop codons have the value <c>Stop</c>.
        /// </summary>
        public static readonly Dictionary<string, string> RnaCodonTable = new Dictionary<string, string>()
            { {"UUU", "F" }, {"UUC", "F" }, {"UUA", "L" }, {"UUG", "L" }, {"UCU", "S" }, {"UCC", "S" }, {"UCA", "S" }, {"UCG", "S" },
                {"UAU", "Y" }, {"UAC", "Y" }, {"UGU", "C" }, {"UGC", "C" }, {"UGG", "W" }, {"CUU", "L" }, {"CUC", "L" }, {"CUA", "L" }, {"CUG", "L" },
                {"CCU", "P" }, {"CCC", "P" }, {"CCA", "P" }, {"CCG", "P" }, {"CAU", "H" }, {"CAC", "H" }, {"CAA", "Q" }, {"CAG", "Q" },
                {"CGU", "R" }, {"CGC", "R" }, {"CGA", "R" }, {"CGG", "R" }, {"AUU", "I" }, {"AUC", "I" }, {"AUA", "I" }, {"AUG", "M" },
                {"ACU", "T" }, {"ACC", "T" }, {"ACA", "T" }, {"ACG", "T" }, {"AAU", "N" }, {"AAC", "N" }, {"AAA", "K" }, {"AAG", "K" },
                {"AGU", "S" }, {"AGC", "S" }, {"AGA", "R" }, {"AGG", "R" }, {"GUU", "V" }, {"GUC", "V" }, {"GUA", "V" }, {"GUG", "V" },
                {"GCU", "A" }, {"GCC", "A" }, {"GCA", "A" }, {"GCG", "A" }, {"GAU", "D" }, {"GAC", "D" }, {"GAA", "E" }, {"GAG", "E" },
                {"GGU", "G" }, {"GGC", "G" }, {"GGA", "G" }, {"GGG", "G" }, {"UAA", "Stop" }, {"UAG", "Stop" }, {"UGA", "Stop" }
            };

        /// <summary>
        /// DNA codon table. Stop codons have the value <c>Stop</c>.
        /// </summary>
        public static readonly Dictionary<string, string> DnaCodonTable = new Dictionary<string, string>()
            { {"TTT", "F" }, {"TTC", "F" }, {"TTA", "L" }, {"TTG", "L" }, {"TCT", "S" }, {"TCC", "S" }, {"TCA", "S" }, {"TCG", "S" },
                {"TAT", "Y" }, {"TAC", "Y" }, {"TGT", "C" }, {"TGC", "C" }, {"TGG", "W" }, {"CTT", "L" }, {"CTC", "L" }, {"CTA", "L" }, {"CTG", "L" },
                {"CCT", "P" }, {"CCC", "P" }, {"CCA", "P" }, {"CCG", "P" }, {"CAT", "H" }, {"CAC", "H" }, {"CAA", "Q" }, {"CAG", "Q" },
                {"CGT", "R" }, {"CGC", "R" }, {"CGA", "R" }, {"CGG", "R" }, {"ATT", "I" }, {"ATC", "I" }, {"ATA", "I" }, {"ATG", "M" },
                {"ACT", "T" }, {"ACC", "T" }, {"ACA", "T" }, {"ACG", "T" }, {"AAT", "N" }, {"AAC", "N" }, {"AAA", "K" }, {"AAG", "K" },
                {"AGT", "S" }, {"AGC", "S" }, {"AGA", "R" }, {"AGG", "R" }, {"GTT", "V" }, {"GTC", "V" }, {"GTA", "V" }, {"GTG", "V" },
                {"GCT", "A" }, {"GCC", "A" }, {"GCA", "A" }, {"GCG", "A" }, {"GAT", "D" }, {"GAC", "D" }, {"GAA", "E" }, {"GAG", "E" },
                {"GGT", "G" }, {"GGC", "G" }, {"GGA", "G" }, {"GGG", "G" }, {"TAA", "Stop" }, {"TAG", "Stop" }, {"TGA", "Stop" }
            };

        /// <summary>
        /// Downloads protein data from the UniProt database.
        /// </summary>
        /// <param name="uniprotID">The protein ID.</param>
        /// <returns>A FASTA-formatted genetic string.</returns>
        public static string[] UniprotDownload(string uniprotID)
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

        /// <summary>
        /// Parses the monoisotopic mass table for amino acids.
        /// </summary>
        /// <param name="path">Filepath to the mass table.</param>
        /// <returns>A dictionary with parsed mass table values.</returns>
        public static Dictionary<string, decimal> ParseMassTable(string path = @"..\..\..\Datasets\monoisotopicMassTable.txt")
        {
            string[] inputFile = File.ReadAllLines(path);
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

        /// <summary>
        /// Computes the factorial of an <c>int</c> number.
        /// </summary>
        /// <param name="number">The number to factorialise.</param>
        /// <returns>The factorial of <c>number</c>.</returns>
        public static int IntFactorial(int number)
        {
            for (int i = 2; i <= number; i++)
            {
                number *= i;
            }
            return number;
        }

        /// <summary>
        /// Computes the reverse complement of a DNA sequence.
        /// </summary>
        /// <param name="dnaSequence">A DNA sequence.</param>
        /// <returns>The reverse complement of a DNA sequence.</returns>
        public static string GetReverseComplement(string dnaSequence)
        {
            char[] s = dnaSequence.ToCharArray();
            Array.Reverse(s);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A') { s[i] = 'T'; }
                else if (s[i] == 'T') { s[i] = 'A'; }
                else if (s[i] == 'C') { s[i] = 'G'; }
                else if (s[i] == 'G') { s[i] = 'C'; }
            }
            string complement = new string(s);
            return complement;
        }

        /// <summary>
        /// Transcribes DNA to RNA.
        /// </summary>
        /// <param name="dnaSequence">The DNA sequence to transcribe.</param>
        /// <returns>The transcribed RNA sequence.</returns>
        public static string TranscribeDNAtoRNA(string dnaSequence)
        {
            string rnaSequence = dnaSequence.Replace('T', 'U');
            return rnaSequence;
        }
    }
}