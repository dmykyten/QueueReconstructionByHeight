using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueReconstructionByHeight
{
    public class Queue
    {
        public Person[] people;

        public bool IsValid()
        {
            throw new NotImplementedException("Implement me");
        }

        // check whether person can be added to the end of this particular queue. I.e. Is person's HigherInFront matches for this queue
        public bool canPersonBeAdded(Person person)
        {
            throw new NotImplementedException("Implement me");
        }

        // Add new person to the end
        public Queue FormNewQueue(Person person)
        {
            throw new NotImplementedException("Implement me");
        }

    }
}
