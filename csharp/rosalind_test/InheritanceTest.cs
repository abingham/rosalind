using NUnit.Framework;
using System;

using rosalind;

namespace rosalind_test
{
    [TestFixture()]
    public class InheritanceTest
    {
        [Test()]
        public void TestSelectionProb()
        {
            var pop = new rosalind.Inheritance.Population () {
                { Inheritance.GeneType.H, 1 },
                { Inheritance.GeneType.HD, 1 },
                { Inheritance.GeneType.HR, 1 }
            };
            var expected = new Rational (1, 3);
            Assert.That (
                Inheritance.selectionProb (Inheritance.GeneType.H, pop),
                Is.EqualTo (expected));
        }

        [Test()]
        public void TestDominantProbability()
        {
            float expected = 0.783333361f;

            Rational result = Inheritance.dominantProbability (2, 2, 2);
            Assert.That (
                (float)result.Numerator / result.Denominator,
                Is.EqualTo (expected));
        }
    }
}

