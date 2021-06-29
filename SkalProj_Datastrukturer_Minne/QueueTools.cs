using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public static class QueueTools
    {

    }

    public class QueueEntry
    {
        public string QueueAction { get; }
        public string QueueEntryLabel { get; }

        public QueueEntry (string sourceString)
        {
            QueueAction = sourceString[0].ToString();
            QueueEntryLabel = sourceString.Substring(1);
        }
    }
}
