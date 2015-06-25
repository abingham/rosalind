using System;
using System.Collections.Generic;

namespace rosalind
{
    static public class Motif
    {
        public static IEnumerable<int> findMotif(string dna, string motif)
        {
            for (int i = 0; i <= dna.Length - motif.Length; i++) {
                var sub = dna.Substring (i, motif.Length);
                if (sub == motif)
                    yield return i + 1;
            }
        }
    }
}

