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
                { Inheritance.Gene.H, 1 },
                { Inheritance.Gene.HD, 1 },
                { Inheritance.Gene.HR, 1 }
            };
            var expected = new Rational (1, 3);
            Assert.That (
                Inheritance.selectionProb (Inheritance.Gene.H, pop),
                Is.EqualTo (expected));
        }

        [Test()]
        public void TestDominantProbability()
        {
            float expected = 0.78333f;

            Rational result = Inheritance.dominantProbability (2, 2, 2);
            Assert.That (
                (float)result.Numerator / result.Denominator,
                Is.EqualTo (expected));
        }
    }
}

