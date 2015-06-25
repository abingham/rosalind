using NUnit.Framework;
using System;

using rosalind;

namespace rosalind_test
{
    [TestFixture()]
    public class RationalTest
    {
        [Test()]
        public void TestAdd()
        {
            Rational r = new Rational (1, 3) + new Rational (3, 11);
            Rational expected = new Rational(11 + 9, 33);
            Assert.That (expected, Is.EqualTo (r));

            Assert.That (new Rational (1, 2) + new Rational (1, 2),
                Is.EqualTo (new Rational (1, 1)));
        }

        [Test()]
        public void TestMultiply()
        {
            Rational r = new Rational (1, 3) * new Rational (3, 11);
            Rational expected = new Rational(3, 33);
            Assert.That (expected, Is.EqualTo (r));
        }

        [Test()]
        public void TestAddingToZeroReturnsNonZero()
        {
            var orig = new Rational (1, 3);
            var zero = new Rational (0);
            var sum = orig + zero;
            Assert.That (sum, Is.EqualTo (orig));

            sum = zero + orig;
            Assert.That (sum, Is.EqualTo (orig));
        }

        [Test()]
        public void TestAddingZeroToZeroIsZero()
        {
            var r1 = new Rational (0);
            var r2 = new Rational (0);
            var sum = r1 + r2;
            Assert.That (sum, Is.EqualTo (new Rational (0)));
        }
    }
}

