﻿using NUnit.Framework;
using System;

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
    }
}

