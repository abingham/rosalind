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
      rosalind-cli.exe seasonal-wabbits <months> <lifespan>
      rosalind-cli.exe max-gc <filename>
      rosalind-cli.exe hamming <filename>
      rosalind-cli.exe dom-prob <hd> <h> <hr>
      rosalind-cli.exe translate-rna <filename>
      rosalind-cli.exe find-motif <dna> <motif>
      rosalind-cli.exe consensus <filename>
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

        private static void SeasonalWabbit(IDictionary<string, ValueObject> args)
        {
            int months = args ["<months>"].AsInt;
            int lifespan = args ["<lifespan>"].AsInt;
            var result = rosalind.Wabbits.seasonalWabbits (lifespan);
            Console.WriteLine(result.ElementAt(months - 1));
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

        private static void Consensus(IDictionary<string, ValueObject> args)
        {
            string filename = args ["<filename>"].ToString ();

            int size = 0;
            using (var infile = new FileStream (filename, FileMode.Open)) {
                var reader = new StreamReader (infile);

                foreach (var pair in FASTA.read(reader)) {
                    size = pair.Item2.Length;
                }
            }

            var profile = new Profile ((uint)size);

            using (var infile = new FileStream (filename, FileMode.Open)) {
                var reader = new StreamReader (infile);

                foreach (var pair in FASTA.read(reader)) {
                    var seq = pair.Item2.Select (b => (Base)Enum.Parse (typeof(Base), b.ToString()));
                    profile.add (seq);
                }
            }

            Console.WriteLine (string.Join("", profile.consensus));

            Console.Write ("A: ");
            Console.WriteLine (string.Join (" ", profile [Base.A]));
            Console.Write ("C: ");
            Console.WriteLine (string.Join (" ", profile [Base.C]));
            Console.Write ("G: ");
            Console.WriteLine (string.Join (" ", profile [Base.G]));
            Console.Write ("T: ");
            Console.WriteLine (string.Join (" ", profile [Base.T]));
        }

        private static IDictionary<string, Action<IDictionary<string, ValueObject>>> commandMap = 
            new Dictionary<string, Action<IDictionary<string, ValueObject>>>() {
                {"count-nucleotides", CountNucleotides},
                {"transcribe", Transcribe},
                {"wabbits", Wabbits},
                {"seasonal-wabbits", SeasonalWabbit},   
                {"max-gc", GCContent},
                {"hamming", HammingDistance},
                {"dom-prob", DominantProbability},
                {"translate-rna", TranslateRNA},
                {"find-motif", FindMotif},
                {"consensus", Consensus}
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
