﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using rosalind;

namespace rosalind_test
{
    [TestFixture ()]
    public class Test
    {

        [Test ()]
        public void TestCountingNucleotides ()
        {
            const string input = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC";
            var result = rosalind.CountingNucleotides.count (input);

            Assert.That(result['A'], Is.EqualTo(20) );
            Assert.That(result['C'], Is.EqualTo(12) );   
            Assert.That(result['G'], Is.EqualTo(17) );
            Assert.That(result['T'], Is.EqualTo(21) );
            Assert.That (result.Keys.Count, Is.EqualTo (4));
        }

        [Test ()]
        public void TestTranscribe ()
        {
            const string input = "GATGGAACTTGACTACGTAAATT";
            const string expected = "GAUGGAACUUGACUACGUAAAUU";
            Assert.That (rosalind.Transcriber.Transcribe (input), Is.EqualTo (expected));
        }

        [Test ()]
        public void TestComplement ()
        {
            const string input = "AAAACCCGGT";
            const string expected = "ACCGGGTTTT";
            Assert.That (rosalind.Complementer.Complement (input), Is.EqualTo (expected));
        }

	    [Test()]
	    public void TestWabbits ()
	    {
	        Assert.That(Wabbits.wabbits(5, 3), Is.EqualTo(19));
	    }

        [Test()]
        public void TestSeasonalWabbits()
        {
            UInt64 rslt = Wabbits.seasonalWabbits (3).ElementAt (5);
            Assert.AreEqual (4, rslt);
        }

        [Test()]
        public void TestGCContent()
        {
            const string input = "CCACCCTCGTGGTATGGCTAGGCATTCAGGAACCGGAGAACGCTTCAGACCAGCCCGGACTGGGAACCTGCGGGCAGTAGGTGGAAT";
            const float expected = 60.919540f;
            Assert.That (GCContentCalculator.GCContent (new StringReader(input)), Is.EqualTo (expected));
        }

        [Test()]
        public void TestGCContents()
        {
            const string input = @">Rosalind_6404
            CCTGCGGAAGATCGGCACTAGAATAGCCAGAACCGTTTCTCTGAGGCTTCCGGCCTTCCC
            TCCCACTAATAATTCTGAGG
            >Rosalind_5959
            CCATCGGTAGCGCATCCTTAGTCCAATTAAGTCCCTATCCAGGCGCTCCGCCGAAGGTCT
            ATATCCATTTGTCAGCAGACACGC
            >Rosalind_0808
            CCACCCTCGTGGTATGGCTAGGCATTCAGGAACCGGAGAACGCTTCAGACCAGCCCGGAC
            TGGGAACCTGCGGGCAGTAGGTGGAAT";

            var expected = new List<Tuple<string, float>> () {
                Tuple.Create ("Rosalind_6404", 53.75f),
                Tuple.Create ("Rosalind_5959", 53.57143f),
                Tuple.Create ("Rosalind_0808", 60.919540f)
            };
            var result = new List<Tuple<string, float>>(GCContentCalculator.GCContents(new StringReader(input)));

            Assert.That (result, Is.EqualTo (expected));
        }

        [Test()]
        public void TestMaxGCContent() 
        {
            const string input = @">Rosalind_6404
            CCTGCGGAAGATCGGCACTAGAATAGCCAGAACCGTTTCTCTGAGGCTTCCGGCCTTCCC
            TCCCACTAATAATTCTGAGG
            >Rosalind_5959
            CCATCGGTAGCGCATCCTTAGTCCAATTAAGTCCCTATCCAGGCGCTCCGCCGAAGGTCT
            ATATCCATTTGTCAGCAGACACGC
            >Rosalind_0808
            CCACCCTCGTGGTATGGCTAGGCATTCAGGAACCGGAGAACGCTTCAGACCAGCCCGGAC
            TGGGAACCTGCGGGCAGTAGGTGGAAT";

            var expected = Tuple.Create ("Rosalind_0808", 60.919540f);

            Assert.That (GCContentCalculator.MaxGCContent(new StringReader(input)), 
                         Is.EqualTo (expected));     
        }

        [Test()]
        public void TestHammingDistance()
        {
            const string s1 = "GAGCCTACTAACGGGAT";
            const string s2 = "CATCGTAATGACGGCCT";
            const int expected = 7;
            Assert.That(
                Hamming.Distance (
                    new StringReader (s1), 
                    new StringReader (s2)),
                Is.EqualTo (expected));
        }

        [Test()]
        public void TestTranslateRNA()
        {
            string input = "AUGGCCAUGGCGCCCAGAACUGAGAUCAAUAGUACCCGUAUUAACGGGUGA";
            string expected = "MAMAPRTEINSTRING";
            var result = TranslateRNA.codonsToAminoAcids (new StringReader (input));

            Assert.IsTrue(result.Zip (expected, (a, b) => a == b).All (x => x));
        }

        [Test()]
        public void TestConsensus()
        {
            string input = @">Rosalind_1
            ATCCAGCT
            >Rosalind_2
            GGGCAACT
            >Rosalind_3
            ATGGATCT
            >Rosalind_4
            AAGCAACC
            >Rosalind_5
            TTGGAACT
            >Rosalind_6
            ATGCCATT
            >Rosalind_7
            ATGGCACT";

            var profile = new Profile (8);
            foreach (var pair in FASTA.read(new StringReader(input))) {
                var seq = pair.Item2.Select (b => (Base)Enum.Parse (typeof(Base), b.ToString()));
                profile.add (seq);
            }

            var expectedConcensus = "ATGCAACT".Select(b => (Base)Enum.Parse(typeof(Base), b.ToString()));
            IDictionary<Base, IList<uint>> expectedProfile = new Dictionary<Base, IList<uint>> () {
                { Base.A, new List<uint> (){ 5, 1, 0, 0, 5, 5, 0, 0 } },
                { Base.C, new List<uint> (){ 0, 0, 1, 4, 2, 0, 6, 1 } },
                { Base.G, new List<uint> (){ 1, 1, 6, 3, 0, 1, 0, 0 } },
                { Base.T, new List<uint> (){ 1, 5, 0, 0, 0, 1, 1, 6 } }    
            };

            Assert.That (profile.consensus, Is.EqualTo (expectedConcensus));

            foreach (Base b in Enum.GetValues(typeof(Base))) {
                Assert.That(
                    new List<uint>(profile[b]), 
                    Is.EqualTo(expectedProfile[b]));
            }
        }

        [Test()]
        public void OverlapGraphTest()
        {
            string input = @">Rosalind_0498
                             AAATAAA
                             >Rosalind_2391
                             AAATTTT
                             >Rosalind_2323
                             TTTTCCC
                             >Rosalind_0442
                             AAATCCC
                             >Rosalind_5013
                             GGGTGGG";
            
            var expected = new List<Tuple<string, string>> () {
                Tuple.Create ("Rosalind_0498", "Rosalind_2391"),
                Tuple.Create ("Rosalind_0498", "Rosalind_0442"),
                Tuple.Create ("Rosalind_2391", "Rosalind_2323")
            };

            var result = new List<Tuple<string, string>> (
                OverlapGrapher.calculateGraph (3, FASTA.read (new StringReader (input))));

            Assert.AreEqual (expected.Count, result.Count);

            foreach (var pair in expected.Zip(result, (a, b) => Tuple.Create(a, b))) {
                Assert.AreEqual (pair.Item1, pair.Item2);
            }
        }

        [Test()]
        public void ExpectedOffspringTest()
        {
            var expected = ExpectedOffspring.calc (1, 0, 0, 1, 0);
            Assert.AreEqual (3.5, (float)expected.Numerator / expected.Denominator);
        }
    }
}

