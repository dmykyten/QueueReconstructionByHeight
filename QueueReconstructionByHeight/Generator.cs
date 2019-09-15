using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueReconstructionByHeight
{
    public class Generator
    {
        public Queue GenerateValidQueue(int size)
        {
            var people = new Person[size];
            Random rnd = new Random();
            for (int i = 0; i != size; i++){
                people[i] = new Person();
                people[i].Height = rnd.Next(4, 11);
                for (int j = 0; j != i; j++){
                    if (people[i].Height <= people[j].Height)
                        people[i].HigherInFront++;
                       
                }
                Console.WriteLine("h: " + people[i].Height + " front:" + people[i].HigherInFront);
            }
            var result = new Queue();
            result.people = people;
            return result;
        }

        // it takes correct queu and shuffle (un-sort) it.
        public Queue ShuffleQueue(Queue validQueue)
        {
            throw new NotImplementedException("Implement me!");
        }
    }
}
