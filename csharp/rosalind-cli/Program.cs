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

        private static void Main(string[] args)
        {
            var arguments = new Docopt().Apply(usage, args, version: "rosalind-cli", exit: true);

            if (arguments ["count-nucleotides"].IsTrue) {
                CountNucleotides (arguments);
            } else if (arguments ["transcribe"].IsTrue) {
                Transcribe (arguments);
            } else if (arguments ["wabbits"].IsTrue) {
                Wabbits (arguments);
            } else if (arguments ["max-gc"].IsTrue) {
                GCContent (arguments);
            }
        }
    }
}
