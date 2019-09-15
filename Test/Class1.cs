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
    }
}
