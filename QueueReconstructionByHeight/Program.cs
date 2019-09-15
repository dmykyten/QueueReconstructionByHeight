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
            Generator obj = new Generator();
            obj.GenerateValidQueue(10);
            Console.ReadLine();
        }
    }
}
