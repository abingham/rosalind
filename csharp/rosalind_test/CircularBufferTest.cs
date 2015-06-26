using NUnit.Framework;
using System;
using System.Diagnostics.Contracts;

using rosalind;

namespace rosalind_test
{
    [TestFixture()]
    public class CircularBufferTest
    {
        [Test()]
        public void TestInitialState() 
        {
            int cap = 10;
            var b = new CircularBuffer<int> (cap);
            Assert.AreEqual (b.capacity, cap);
            Assert.AreEqual (b.size, 0);   
        }
      
        [Test()]
        public void TestPushFrontIncreasesSize()
        {
            var b = new CircularBuffer<int> (10);
            b.pushFront (42);
            Assert.AreEqual (b.size, 1);
        }

        [Test()]
        public void TestPushFrontAddsElement()
        {
            var b = new CircularBuffer<int> (10);
            b.pushFront (42);
            Assert.AreEqual (b[0], 42);
        }

        [Test()]
        public void TestPopFrontReturnsAndRemovesItem()
        {
            var b = new CircularBuffer<int> (10);
            b.pushFront (42);
            b.pushFront (69);
            Assert.AreEqual (b.popFront (), 69);
            Assert.AreEqual (b [0], 42);
            Assert.AreEqual (b.size, 1);
        }

        [Test()]
        public void TestPopFrontOnEmptyBufferThrows()
        {
            var b = new CircularBuffer<int> (10);
            try
            {
                b.popFront();
            }
            catch (Exception ex)
            {
                Assert.True(ex.GetType().Name == "ContractException");
                return;
            }
            Assert.Fail("ContractException has not been thrown.");
        }

        [Test()]
        public void TestPushBackIncreasesSize()
        {
            var b = new CircularBuffer<int> (10);
            b.pushBack (42);
            Assert.AreEqual (b.size, 1);
        }

        [Test()]
        public void TestPushBackAddsElement()
        {
            var b = new CircularBuffer<int> (10);
            b.pushBack (42);
            Assert.AreEqual (b[0], 42);
        }

        [Test()]
        public void TestPopBackReturnsAndRemovesItem()
        {
            var b = new CircularBuffer<int> (10);
            b.pushFront (42);
            b.pushFront (69);
            Assert.AreEqual (b.popBack (), 42);
            Assert.AreEqual (b [0], 69);
            Assert.AreEqual (b.size, 1);
        }

        [Test()]
        public void TestPopBackOnEmptyBufferThrows()
        {
            var b = new CircularBuffer<int> (10);
            try
            {
                b.popBack();
            }
            catch (Exception ex)
            {
                Assert.True(ex.GetType().Name == "ContractException");
                return;
            }
            Assert.Fail("ContractException has not been thrown.");
        }

        [Test()]
        public void TestCapacityCanBeReachedAtMiddle() {
            var b = new CircularBuffer<int> (10);
            for (int i = 0; i < b.capacity; ++i) {
                b.pushBack (42);    
            }
            for (int i = 0; i < b.capacity / 2; ++i) {
                b.popFront ();    
            }
            for (int i = 0; i < b.capacity / 2; ++i) {
                b.pushBack (42);    
            }

            try
            {
                b.pushBack(1337);
            }
            catch (Exception ex)
            {
                Assert.True(ex.GetType().Name == "ContractException");
                return;
            }
            Assert.Fail("ContractException has not been thrown.");
        }
    }
}

