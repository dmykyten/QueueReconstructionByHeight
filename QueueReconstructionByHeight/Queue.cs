using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueReconstructionByHeight
{
    public class Queue
    {
        public Person[] people { get; private set; }
        
        public Queue(int size)
        {
            people = new Person[size];
        }
        public void Show()
        {
            foreach (Person person in people)
            {
                Console.Write($"[h: {person.Height} front: { + person.HigherInFront}] ");
            }
            Console.WriteLine();
        }

        public bool IsValid()
        {
            if (people.Length == 0)
                return true;
            if (people[0].HigherInFront != 0)
                return false;
            for (int i = 1; i != people.Length; i++)
            {
                int HigherInFront = 0;
                for (int j = 0; j != i; j++)
                {
                    if (people[j].Height >= people[i].Height)
                        HigherInFront++;
                    //Console.WriteLine("j.height: " + people[j].Height + " i.height: " + people[i].Height + " HInF: " + HigherInFront);
                }
                if (people[i].HigherInFront != HigherInFront)
                    return false;
            }
            return true;
        }

        // check whether person can be added to the end of this particular queue. I.e. Is person's HigherInFront matches for this queue
        public bool CanPersonBeAdded(Person person)
        {

            return IsValid() && AppendToQueue(person).IsValid();
        }

        // Add new person to the end
        public Queue AppendToQueue(Person person)
        {
            var newQueue = new Queue(people.Length + 1);
            for (int i = 0; i != newQueue.people.Length - 1; i++)
            {
                var temp_person = new Person();
                temp_person.Height = people[i].Height;
                temp_person.HigherInFront = people[i].HigherInFront;
                newQueue.people[i] = temp_person;
            }
            newQueue.people[people.Length] = person;
            return newQueue;
        }

        public Queue RemoveFromQueue(int position)
        {
            var newQueue = new Queue(people.Length - 1);
            for(int i = 0; i < position; i++)
            {
                var temp_person = new Person();
                temp_person.Height = people[i].Height;
                temp_person.HigherInFront = people[i].HigherInFront;
                newQueue.people[i] = temp_person;
            }
            for(int i = position + 1; i < people.Length; i++)
            {
                var temp_person = new Person();
                temp_person.Height = people[i].Height;
                temp_person.HigherInFront = people[i].HigherInFront;
                newQueue.people[i - 1] = temp_person;
            }
            return newQueue;
        }

        private Queue Sort(Queue unsorted)
        {
            if(unsorted.people.Length == 0 && this.IsValid())
            {
                return this;
            }
            if (!this.IsValid())
            {
                return null;
            }
            for(int i = 0; i != unsorted.people.Length; i++)
            {
                if (CanPersonBeAdded(unsorted.people[i]))
                {
                    var newQueue = AppendToQueue(unsorted.people[i]);
                    var newUnsorted = unsorted.RemoveFromQueue(i);
                    var newSorted = newQueue.Sort(newUnsorted);
                    if (newSorted != null)
                        return newSorted;
                }
            }
            return null;
        }


        public Queue Sort()
        {
            return new Queue(0).Sort(this);
        }

    }
}
