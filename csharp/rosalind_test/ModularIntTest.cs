using NUnit.Framework;
using System;

using rosalind;

namespace rosalind_test
{
    [TestFixture()]
    public class ModularIntTest
    {
        [Test()]
        public void TestConstructorModulosValue() {
            var x = new ModularInt (10, 3);
            const int expectedValue = 1;
            Assert.That (x.value, Is.EqualTo (expectedValue));
        }

        [Test()]
        public void TestAdditionWithIntsPeformsModulo() {
            var result = new ModularInt (2, 3) + 2;
            var expected = new ModularInt (1, 3);
            Assert.That (result, Is.EqualTo (expected));
        }

        [Test()]
        public void TestAdditionWithModIntsPeformsModulo() {
            var result = new ModularInt (2, 3) + new ModularInt(2, 3);
            var expected = new ModularInt (1, 3);
            Assert.That (result, Is.EqualTo (expected));
        }

        [Test()]
        public void TestSubtractionWithIntsPerformsModulo() {
            var result = new ModularInt(1, 5) - 3;
            var expected = new ModularInt (3, 5);
            Assert.That (result, Is.EqualTo (expected));
        }

        [Test()]
        public void TestSubtractionWithModIntsPerformsModulo() {
            var result = new ModularInt(1, 5) - new ModularInt(3, 123);
            var expected = new ModularInt (3, 5);
            Assert.That (result, Is.EqualTo (expected));
        }
    }
}

