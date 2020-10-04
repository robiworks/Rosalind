using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rosalind.Solutions
{
    internal class MPRT
    {
        public static string GetProteinLocations()
        {
            // Write input file with protein IDs to string array
            string[] input = File.ReadAllLines(@"..\..\..\Datasets\rosalind_mprt.txt");
            List<string> outputList = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                // Parse current protein from input to dictionary with key (protein ID) and value (sequence)
                string[] proteinData = Library.UniprotDownload(input[i]);
                Dictionary<string, string> temp = Library.ParseFastaToDictionary(proteinData);

                // Regex for capturing the N-glycosylation motif N{P}[ST]{P}
                Regex motif = new Regex("N[^P](S|T)[^P]");
                string protein = temp.ElementAt(0).Value; // Protein sequence
                string identifier = temp.ElementAt(0).Key; // Protein identifier
                if (motif.IsMatch(protein))
                {
                    outputList.Add(identifier);
                    string locations = "";
                    foreach (Match match in motif.Matches(protein))
                    {
                        locations += (match.Index + 1).ToString() + " ";
                        if (motif.IsMatch(protein.Substring(match.Index + 1, 4))) // Additional code if motif is contained inside an existing match
                        {
                            locations += (match.Index + 2).ToString() + " ";
                        }
                    }
                    locations = locations.Trim(); // Remove any unnecessary whitespace
                    outputList.Add(locations);
                }
            }

            // Convert list with motif locations to array for file writing
            string[] output = outputList.ToArray();
            File.WriteAllLines(@"..\..\..\Output\mprt.txt", output);
            return @"Output written to Output\mprt.txt";
        }

        public static string GetProteinLocationsNoRegex() // Because the solution above is kinda overkill, LMAO. I like to overthink, do I? I've been doing RegEx recently so I guess that's why. They execute in similar time, this one even slower on my laptop.
        {
            // Write input file with protein IDs to string array
            string[] input = File.ReadAllLines(@"..\..\..\Datasets\rosalind_mprt.txt");
            List<string> outputList = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                // Parse current protein from input to dictionary with key (protein ID) and value (sequence)
                string[] proteinData = Library.UniprotDownload(input[i]);
                Dictionary<string, string> temp = Library.ParseFastaToDictionary(proteinData);

                string protein = temp.ElementAt(0).Value; // Protein sequence
                string identifier = temp.ElementAt(0).Key; // Protein identifier

                // Match the motif N{P}[ST]{P} without RegEx
                bool hasIdentifier = false;
                string locations = "";
                for (int j = 0; j < protein.Length - 3; j++)
                {
                    if (protein[j] == 'N' && protein[j + 1] != 'P' && (protein[j + 2] == 'S' || protein[j + 2] == 'T') && protein[j + 3] != 'P')
                    {
                        if (!hasIdentifier)
                        {
                            outputList.Add(identifier);
                            hasIdentifier = true;
                        }
                        locations += (j + 1).ToString() + " ";
                    }
                }
                if (hasIdentifier)
                {
                    locations = locations.Trim();
                    outputList.Add(locations);
                }
            }

            // Convert list with motif locations to array for file writing
            string[] output = outputList.ToArray();
            File.WriteAllLines(@"..\..\..\Output\mprt.txt", output);
            return @"Output written to Output\mprt.txt";
        }
    }
}