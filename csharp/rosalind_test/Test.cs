using NUnit.Framework;
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
        public void TestMotif()
        {
            string input = "GATATATGCATATACTT";
            string motif = "ATAT";
            var expected = new List<int> (){ 2, 4, 10 };
            var result = new List<int>(Motif.findMotif (input, motif));
            Assert.That (expected, Is.EqualTo (result));
        }
    }
}

