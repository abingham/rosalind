using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using rosalind;

namespace rosalind_test
{
    [TestFixture()]
    public class MotifTest
    {
        [Test()]
        public void TestMotif()
        {
            string input = "GATATATGCATATACTT";
            string motif = "ATAT";
            var expected = new List<int> (){ 2, 4, 10 };
            var result = new List<int>(Motif.findMotif (input, motif));
            Assert.That (expected, Is.EqualTo (result));
        }

        [Test()]
        public void TestSubstrings() {
            string input = "xabxabc";
            var expected = new List<string> () {
                "x", "xa", "xab", "xabx", "xabxa", "xabxab", "xabxabc",
                "a", "ab", "abx", "abxa", "abxab", "abxabc",
                "b", "bx", "bxa", "bxab", "bxabc",
                "xabc", "abc", "bc", "c"
            };
            expected.Sort ();

            var results = MotifTracker.substrings (input).Distinct().ToList();
            results.Sort ();

            Assert.AreEqual (expected, results);
        }

        [Test()]
        public void TestSharedMotif()
        {
            const string input = @">Rosalind_1
                GATTACA
                >Rosalind_2
                TAGACCA
                >Rosalind_3
                ATACA";
            const string expected = "AC";
                
            var tracker = FASTA.read (new StringReader (input))
                .Aggregate (new MotifTracker (), 
                            (trk, p) => trk.add (p.Item2));
            Assert.IsTrue (tracker.motifs.Contains (expected));
        }
    }
}

