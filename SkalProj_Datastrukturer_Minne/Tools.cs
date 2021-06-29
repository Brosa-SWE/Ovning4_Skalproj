using System;
using System.Collections.Generic;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    public static class Tools
    {

    }

    public class Entry
    {
        public string Action { get; }
        public string EntryValue { get; }
        public string EntryStory { get; }

        public Entry (string SourceString)
        {
            if (SourceString == "") { SourceString = " "; }

            Action = SourceString[0].ToString();
            EntryValue = SourceString.Substring(1);

            switch (Action)
            {
                case "+":
                    EntryStory = $"{EntryValue} ställer sig i kön";
                    break;

                case "-":
                    EntryStory = $"{EntryValue} blir expedierad och lämnar kön";
                    break;

                default:
                    EntryStory = $"{SourceString} är inte ett giltigt värde";
                    break;
            }

        }
    }
}
