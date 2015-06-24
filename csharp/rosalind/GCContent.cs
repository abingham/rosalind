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

        static public IEnumerable<Tuple<string, float>> GCContents(TextReader input)
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
                        yield return Tuple.Create (tag, GCContent(new StringReader(dna)));
                    }
                    tag = line;
                    dna = "";
                } else {
                    dna += line;
                }
            }

            if (tag.Length != 0) {
                yield return Tuple.Create (tag, GCContent(new StringReader(dna)));
            }
        }

        static public Tuple<string, float> MaxGCContent(TextReader input)
        {
            return GCContents (input).Aggregate (
                (rslt, item) => rslt.Item2 > item.Item2 ? rslt : item);
        }
    }
}

