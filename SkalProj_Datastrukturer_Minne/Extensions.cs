using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    public static class Extensions
    {
        // Extended Queue to allow any queue entry to be removed by its value.
        // Usuage: Queue myQueue = myQueue.Dequeue(stringToRemoveFromQueue);
        public static Queue<string> Dequeue(this Queue<string> queue, String queueElementToRemove)
        {
            return new Queue<string>(queue.Where(x => x != queueElementToRemove));
        }

    }
}
