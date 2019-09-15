using System;
using System.Diagnostics;
using QueueReconstructionByHeight;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var generator = new Generator();
            //var queue = generator.GenerateValidQueue(5);
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            // or Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.WriteLine("Hello World");


        }
    }
}
