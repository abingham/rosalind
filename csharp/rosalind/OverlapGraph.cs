using System;
using System.Collections.Generic;

namespace rosalind
{
    struct Entry {
        public Entry() {
            prefixed = new HashSet<string> ();
            suffixed = new HashSet<string> ();
        }

        internal ISet<string> prefixed;
        internal ISet<string> suffixed;
    };

    public static class OverlapGrapher
    {
        public static IEnumerable<Tuple<string, string>> calculateGraph(
            int overlap_size,
            IEnumerable<Tuple<string, string>> fasta_data) {
            var table = new Dictionary<string, Entry> ();

            foreach (var entry in fasta_data) {
                var tag = entry.Item1;
                var dna = entry.Item2;
                var prefix = dna.Substring (0, overlap_size);
                var suffix = dna.Substring (dna.Length - overlap_size, overlap_size);

                if (!table.ContainsKey(prefix)) {
                    table.Add (prefix, new Entry ());
                }

                if (!table.ContainsKey(suffix)) {
                    table.Add (suffix, new Entry ());
                }

                table [prefix].prefixed.Add (tag);
                table [suffix].suffixed.Add (tag);
            }

            foreach (var entry in table) {
                foreach (var suff in entry.Value.suffixed) {
                    foreach (var pref in entry.Value.prefixed) {
                        if (suff != pref) {
                            yield return Tuple.Create (suff, pref);
                        }
                    }
                }
            }
        }
    }
}

