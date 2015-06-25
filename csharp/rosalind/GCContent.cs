using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace rosalind
{
    static public class GCContentCalculator
    {
        static public float GCContent(TextReader data)
        {
            Int32 cgCount = 0;
            Int32 fullCount = 0;
            Int32 b;
            while ((b = data.Read()) != -1) {
                fullCount += 1;
                if (b == 'C' || b == 'G') {
                    cgCount += 1;
                }
            }
            return (float)cgCount / fullCount * 100;
        }

        /*
         * Parse a FASTA-formatted stream, generating a sequence of (tag, gc-content) tuples.
         */  
        static public IEnumerable<Tuple<string, float>> GCContents(TextReader input)
        {
            foreach (var pair in FASTA.read(input)) {
                yield return Tuple.Create (
                    pair.Item1, 
                    GCContent (new StringReader (pair.Item2)));
            }
        }

        static public Tuple<string, float> MaxGCContent(TextReader input)
        {
            return GCContents (input).Aggregate (
                (rslt, item) => rslt.Item2 > item.Item2 ? rslt : item);
        }
    }
}

