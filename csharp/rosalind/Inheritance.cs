using System;
using System.Collections.Generic;
using System.Linq;

namespace rosalind
{
    public static class Inheritance
    {
        public enum Gene {HD, H, HR};
   
        public class Population : Dictionary<Gene, uint> {
            public Population() : base() {}
            public Population(IDictionary<Gene, uint> d) : base(d) {}
        }

        public static IEnumerable<Tuple<Gene, Gene>> allPairings() {
            var genes = new List<Gene>(){ Gene.HD, Gene.H, Gene.HR};
            foreach (var g1 in genes) {
                foreach (var g2 in genes) {
                    yield return Tuple.Create (g1, g2);
                }
            }
        }

        static Rational dominantProb(Gene a, Gene b) {
            if (a == Gene.HD || b == Gene.HD)
                return new Rational(1, 1);
            else if (a == Gene.H && b == Gene.H)
                return new Rational(3, 4);
            else if (a == Gene.H || b == Gene.H)
                return new Rational(1, 2);
            else
                return new Rational(0, 1);
        }

        public static Rational selectionProb(Gene g, Population pop) {
            return new Rational(pop [g], pop.Values.Aggregate((a, b) => a + b));
        }

        static Rational pairingProb(Gene a, Gene b, Population pop) {
            var subPop = new Population (pop);
            subPop [a] -= 1;
            return selectionProb (a, pop) * selectionProb (b, subPop);
        }

        static IEnumerable<Rational> dominantProbs() {
            return allPairings ().Select (p => dominantProb (p.Item1, p.Item2));
        }

        static IEnumerable<Rational> pairingProbs(Population pop) {
            return allPairings ().Select (p => pairingProb (p.Item1, p.Item2, pop));
        }

        public static Rational dominantProbability(uint hdCount, uint hCount, uint hrCount) {
            Population pop = new Population(){
                {Gene.HD, hdCount},
                {Gene.H, hCount}, 
                {Gene.HR, hrCount}
            };
            return pairingProbs (pop).Zip (dominantProbs (), (p1, p2) => p1 * p2).Aggregate ((rslt, item) => rslt + item);
        }
    }
}

