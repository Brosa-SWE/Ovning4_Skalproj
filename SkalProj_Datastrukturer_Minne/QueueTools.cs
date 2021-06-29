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
        public string QueueEntryValue { get; }
        public string QueueEntryStory { get; }

        public QueueEntry (string sourceString)
        {
            QueueAction = sourceString[0].ToString();
            QueueEntryValue = sourceString.Substring(1);

            switch (QueueAction)
            {
                case "+":
                    QueueEntryStory = $"{QueueEntryValue} ställer sig i kön";
                    break;

                case "-":
                    QueueEntryStory = $"{QueueEntryValue} blir expedierad och lämnar kön";
                    break;

                default:
                    QueueEntryStory = $"{sourceString} är inte ett giltigt värde";
                    break;
            }

        }
    }
}
