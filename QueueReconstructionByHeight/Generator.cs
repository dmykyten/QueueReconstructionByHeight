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
            var result = new Queue(size);
            for (int i = 0; i != size; i++){
                result.people[i] = new Person();
                result.people[i].Height = rnd.Next(4, 11);
                for (int j = 0; j != i; j++){
                    if (result.people[i].Height <= result.people[j].Height)
                        result.people[i].HigherInFront++;
                       
                }
            }

            //result.people = people;

            Console.WriteLine("Valid Queue");
            result.Show(); 
            return result;
        }

        // it takes correct queu and shuffle (un-sort) it.
        static Random rnd = new Random();
        public Queue ShuffleQueue(Queue validQueue)
        {
            var shuffledQueue = new Queue(validQueue.people.Length);
            //shuffledQueue.people = validQueue.people;
            for (int i = 0; i != shuffledQueue.people.Length; i++)
            {
                var person = new Person();
                person.Height = validQueue.people[i].Height;
                person.HigherInFront = validQueue.people[i].HigherInFront;
                shuffledQueue.people[i] = person;
            }

            for(int i = 0;i != shuffledQueue.people.Length; i++)
            {
                var rndNum = rnd.Next(shuffledQueue.people.Length);
                Person person = shuffledQueue.people[i];

                //int x = 10;
                //Person p1 = new Person();
                //int[] arr1 = new int[10];
                //int[] arr2 = arr1;
                //arr2[1] = 1;
                //String test1 = "sdfsdfs";
                //String text2 = new string('1', 'a');


                //Person secondPerson = person;
                //secondPerson.Height = 20;
                //Person thirdPerson = new Person { Height = person.Height, HigherInFront = person.HigherInFront };
                //Queue anotherQueue = new Queue { people = shuffledQueue.people };

                shuffledQueue.people[i] = shuffledQueue.people[rndNum];
                shuffledQueue.people[rndNum] = person;
                //shuffledQueue.people[i].Height = validQueue.people[rndNum].Height;
                //shuffledQueue.people[i].HigherInFront = validQueue.people[rndNum].HigherInFront;
                
            }
            Console.WriteLine("Shuffled queue");
            shuffledQueue.Show();
            return shuffledQueue;
        }
    }
}           