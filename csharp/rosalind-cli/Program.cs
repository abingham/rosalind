using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocoptNet;

using rosalind;

namespace rosalindcli
{
    internal class RosalindCLI
    {
        private const string usage = @"Rosalind CLI.

    Usage:
      rosalind-cli.exe count-nucleotides <filename>
      rosalind-cli.exe transcribe <filename>
      rosalind-cli.exe wabbits <months> <litter-size>
      rosalind-cli.exe max-gc <filename>
      rosalind-cli.exe hamming <filename>
      rosalind-cli.exe dom-prob <hd> <h> <hr>
      rosalind-cli.exe translate-rna <filename>
      rosalind-cli.exe find-motif <dna> <motif>
      rosalind-cli.exe (-h | --help)

    Options:
      -h --help     Show this screen.

    ";

        private static void CountNucleotides(IDictionary<string,ValueObject> args)
        {
            var filename = args["<filename>"].ToString();
            string data = System.IO.File.ReadAllText(filename).Trim();
            var strValues = CountingNucleotides.count(data).Values.Select(v => v.ToString());
            Console.WriteLine(String.Join(" ", strValues));
        }

        private static void Transcribe(IDictionary<string,ValueObject> args)
        {
            string filename = args["<filename>"].ToString();
            string data = System.IO.File.ReadAllText(@filename).Trim();
            Console.WriteLine(rosalind.Transcriber.Transcribe(data));    
        }

        private static void Wabbits(IDictionary<string,ValueObject> args)
        {
            int n = args["<months>"].AsInt;
            int k = args ["<litter-size>"].AsInt;
            Console.WriteLine (rosalind.Wabbits.wabbits (n, k));    
        }

        private static void GCContent(IDictionary<string,ValueObject> args)
        {
            string filename = args["<filename>"].ToString();
            using (var infile = new FileStream (filename, FileMode.Open)) {
                var result = GCContentCalculator.MaxGCContent (
                    new StreamReader (infile));
                Console.WriteLine (result.Item1);
                Console.WriteLine (result.Item2);
            }
        }

        private static void HammingDistance(IDictionary<string,ValueObject> args)
        {
            string filename = args ["<filename>"].ToString();

            using (var f = new FileStream (filename, FileMode.Open)) {
                var reader = new StreamReader (f);
                var l1 = reader.ReadLine ().Trim ();
                var l2 = reader.ReadLine ().Trim ();

                Console.WriteLine (Hamming.Distance (new StringReader(l1), new StringReader(l2)));
            }
        }

        private static void DominantProbability(IDictionary<string,ValueObject> args)
        {
            uint hd = (uint)args ["<hd>"].AsInt;
            uint h = (uint)args ["<h>"].AsInt;
            uint hr = (uint)args ["<hr>"].AsInt;
            
            var prob = Inheritance.dominantProbability (hd, h, hr);
            Console.WriteLine ((float)prob.Numerator / prob.Denominator);
        }

        private static void TranslateRNA(IDictionary<string,ValueObject> args)
        {
            string filename = args ["<filename>"].ToString ();
            using (var infile = new FileStream (filename, FileMode.Open)) {
                var reader = new StreamReader (infile);
                var result = rosalind.TranslateRNA.codonsToAminoAcids (reader);
                Console.WriteLine(string.Join ("", result));
            }
        }

        private static void FindMotif(IDictionary<string,ValueObject> args)
        {
            var dna = args ["<dna>"].ToString ();
            var motif = args ["<motif>"].ToString ();
            var results = Motif.findMotif (dna, motif);
            var output = string.Join (" ", results); 
            Console.WriteLine (output);
        }

        private static IDictionary<string, Action<IDictionary<string, ValueObject>>> commandMap = 
            new Dictionary<string, Action<IDictionary<string, ValueObject>>>() {
                {"count-nucleotides", CountNucleotides},
                {"transcribe", Transcribe},
                {"wabbits", Wabbits},
                {"max-gc", GCContent},
                {"hamming", HammingDistance},
                {"dom-prob", DominantProbability},
                {"translate-rna", TranslateRNA},
                {"find-motif", FindMotif}  
        };

        private static void Main(string[] args)
        {
            var arguments = new Docopt().Apply(usage, args, version: "rosalind-cli", exit: true);

            foreach (var entry in commandMap) {
                if (arguments [entry.Key].IsTrue) {
                    entry.Value (arguments);
                }
            }
        }
    }
}
