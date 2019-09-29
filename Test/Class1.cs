using NUnit.Framework;
using System;
using QueueReconstructionByHeight;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            Console.WriteLine("Hello");
            var generator = new Generator();
            var queue = generator.GenerateValidQueue(10);
            Assert.IsTrue(queue.people.Length == 10);
        } 

        [Test]
        public void Test2()
        {
            var generator = new Generator();
            var queue = generator.GenerateValidQueue(100);
            Assert.IsTrue(queue.IsValid());
        }

        [Test]
        public void Test3()
        {
            var generator = new Generator();
            var queue1 = generator.GenerateValidQueue(5);
            Console.Write("First");
            queue1.Show();
            var queue2 = generator.GenerateValidQueue(5);
            Console.Write("Second");
            queue2.Show();
            Console.Write("First (one more time)");
            queue1.Show();
            Assert.IsFalse(AreEqual(queue1, queue2));

            var queue1Shuffled = generator.ShuffleQueue(queue1);
            Console.Write("queue1Shuffled");
            queue1Shuffled.Show();
            Console.Write("First");
            queue1.Show();
            var queue2Shuffled = generator.ShuffleQueue(queue2);
            Console.Write("queue2Shuffled");
            queue2Shuffled.Show();
            Console.Write("Second");
            queue2.Show();

            Assert.IsFalse(AreEqual(queue1, queue1Shuffled));
            Assert.IsFalse(AreEqual(queue2, queue2Shuffled));
            Assert.IsFalse(AreEqual(queue1Shuffled, queue2Shuffled));
        }

        [Test]
        public void Test4()
        {
            var generator = new Generator();
            var queue1 = generator.GenerateValidQueue(5);
            Console.Write("First");
            queue1.Show();

            var newPerson = new Person { Height = 1, HigherInFront = 5 };

            var newQueue = queue1.AppendToQueue(newPerson);
            Assert.IsTrue(newQueue.people.Length == 6);
            Assert.IsTrue(newQueue.people[5].Height == newPerson.Height);
            Assert.IsTrue(newQueue.people[5].HigherInFront == newPerson.HigherInFront);
        }

        private bool AreEqual(Queue first, Queue second)
        {
            bool equal = first.people.Length == second.people.Length;
            for (int i = 0; equal && i != 100; i++)
            {
                var person1 = first.people[i];
                var person2 = second.people[i];
                equal = equal && (person1.Height == person2.Height) && (person1.HigherInFront == person2.HigherInFront);
            }
            return equal;
        }

        // the same as AreEqual and here just for reference
        private bool AreEqual2(Queue first, Queue second)
        {
            bool equal = first.people.Length == second.people.Length;
            if (!equal)
            {
                return false;
            }
            for (int i = 0; i != 100; i++)
            {
                var person1 = first.people[i];
                var person2 = second.people[i];
                if (person1.Height != person2.Height)
                {
                    return false;
                }
                if (person1.HigherInFront != person2.HigherInFront)
                {
                    return false;
                }
            }
            return true;
        }


    }
}
