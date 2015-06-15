using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericCustomQueue;

namespace GenericCustomQueueTest
{
    [TestClass]
    public class CustomQueueTest
    {
        GenericCustomQueue<int> queue = new GenericCustomQueue<int>();
        [TestMethod]
        public void EnqueueTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Assert.AreEqual(4, queue.Count);
        }
        [TestMethod]
        public void DequeueTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            int actual = queue.Dequeue();
            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        public void PeekTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Dequeue();
            int actual = queue.Peek();
            Assert.AreEqual(2, actual);
        }
        [TestMethod]
        public void GenericTest()
        {
            GenericCustomQueue<string> queue2 = new GenericCustomQueue<string>();
            queue2.Enqueue("string1");
            queue2.Enqueue("string2");
            Assert.AreEqual("string1", queue2.Peek());
        }
        [TestMethod]
        public void EnumeratorTest()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Dequeue();
            int sum = 0;
            foreach (var q in queue)
                sum += q;
            Assert.AreEqual(9, sum);
        }
    }
}
