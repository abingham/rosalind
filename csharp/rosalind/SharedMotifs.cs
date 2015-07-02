using System;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace rosalind
{
    // TODO: We should really be using generalized suffix trees/Ukkonen's algorithm
    // here. Given enough time and interest, I would...

    public class MotifTracker 
    {
        int maxLen_ = 0;
        ISet<string> motifs_ = null;

        static public IEnumerable<string> substrings(string s, int maxLen=-1) {
            if (maxLen < 0)
                maxLen = s.Length;
            
            for (int i = 0; i < s.Length; ++i) {
                for (int j = i + 1; j - i <= maxLen && j <= s.Length; ++j) {
                    yield return s.Substring (i, j - i);
                }
            }
        }

        void bootstrap(string s) {
            Contract.Assert (motifs_ == null);

            maxLen_ = s.Length;
            motifs_ = new HashSet<string> (substrings (s, maxLen_));
        }

        void ingest(string s) {
            Contract.Assert (motifs_ != null);

            motifs_.IntersectWith (
                substrings (s, maxLen_));
            maxLen_ = motifs_.Aggregate (0, (rslt, item) => rslt > item.Length ? rslt : item.Length);
        }

        public MotifTracker add(string s) {
            if (motifs_ == null) {
                bootstrap (s);
            } else {
                ingest (s);
            }

            return this;
        }

        public IEnumerable<string> motifs {
            get { return motifs_; }
        }

        public int maxLen {
            get { return maxLen_; }
        }
    }
}

