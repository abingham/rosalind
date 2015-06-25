using System;
using System.Collections.Generic;
using System.IO;

namespace rosalind
{
    static public class FASTA
    {
        /*
         * Parse a text stream in rosalind's FASTA format, generating a stream of (tag,dna) tuples.
         */
        static public IEnumerable<Tuple<string, string>> read(TextReader input)
        {
            string tag = "";
            string dna = "";
            string line;
            while ((line = input.ReadLine ()) != null) {
                line = line.Trim ();
                if (line.Length == 0)
                    continue;

                if (line.StartsWith (">")) {
                    line = line.Substring (1);
                    if (tag.Length != 0) {
                        yield return Tuple.Create (tag, dna);
                    }
                    tag = line;
                    dna = "";
                } else {
                    dna += line;
                }
            }

            if (tag.Length != 0) {
                yield return Tuple.Create (tag, dna);
            }
        }
    }
}

