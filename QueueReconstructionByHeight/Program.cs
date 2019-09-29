using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueReconstructionByHeight
{
    class Program
    {
        static void Main(string[] args)
        {
            //new TestsInConsole().Test3();

            Generator generator = new Generator();
            Queue sort = generator.GenerateValidQueue(10);
            //generator.ShuffleQueue(generator.GenerateValidQueue(10));
            Queue shuffled = generator.ShuffleQueue(sort);
            Console.WriteLine($"################## sort.IsValid {sort.IsValid()}");
            sort.Show();
            Console.WriteLine($"################## shuffled.IsValid {shuffled.IsValid()}");
            shuffled.Show();
            var sorted = shuffled.Sort();
            Console.WriteLine($"################## sorted.IsValid {sorted.IsValid()}");
            sorted.Show();

            Console.ReadLine();
        }
    }

    class TestsInConsole
    {
        public void AllTests()
        {
            Test1();
            Test2();
            Test3();
        }


        public void Test1()
        {
            Console.WriteLine("Hello");
            var generator = new Generator();
            var queue = generator.GenerateValidQueue(5);
            IsTrue(queue.people.Length == 5);
        }


        public void Test2()
        {
            var generator = new Generator();
            var queue = generator.GenerateValidQueue(5);
            IsTrue(queue.IsValid());
        }


        public void Test3()
        {
            var generator = new Generator();
            var queue1 = generator.GenerateValidQueue(15);
            Console.Write("First");
            queue1.Show();
            var queue2 = generator.GenerateValidQueue(15);
            Console.Write("Second");
            queue2.Show();
            Console.Write("First (one more time)");
            queue1.Show();
            IsFalse(AreEqual(queue1, queue2));

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

            IsFalse(AreEqual(queue1, queue1Shuffled));
            IsFalse(AreEqual(queue2, queue2Shuffled));
            IsFalse(AreEqual(queue1Shuffled, queue2Shuffled));
        }

        private bool AreEqual(Queue first, Queue second)
        {
            bool equal = first.people.Length == second.people.Length;
            for (int i = 0; equal && i != first.people.Length; i++)
            {
                var person1 = first.people[i];
                var person2 = second.people[i];
                equal = equal && (person1.Height == person2.Height) && (person1.HigherInFront == person2.HigherInFront);
            }
            return equal;
        }

        private void IsTrue(bool expression)
        {
            if (!expression)
            {
                throw new Exception();
            }
        }

        private void IsFalse(bool expression)
        {
            IsTrue(!expression);
        }
    }
}
