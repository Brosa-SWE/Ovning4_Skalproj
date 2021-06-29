using System;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne

/*
1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
Svar: Stacken "staplar" värden så att det senast inlagda kan anses vara "överst" och är det första tillgängliga och sedan nedåt så
att det först inlagda är det sista man kan läsa.

Heapen lagrar värden "intill" varandra så att man kan komma åt vilket av värdena som helst när som helst.

2. Vad är Value Types repsektive Reference Types och vad skiljer dem åt?
Svar: Value Types innehåller själva värdet medans Reference Types innehåller en pekare till en minnesposition där värdet finns.

3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
Svar på metod1: För att x och y är Value Types. x sätts till 3 och y sätts till x (alltså 3), men sedan sätts y om till 4, vilket inte
påverkar x eftersom det är en Value Type så när x returneras innehåller den fortfarande ursprungsvärdet 3.

Svar på metod2: För att x och y är object skapade från Klassen MyInt, dvs de är Reference Types.
x får värdet 3 och y får värdet x vilket betyder att både x och y pekar på samma minnesarea.
När sedan y sätts om till 4 betyder detta att även x.MyValue returnerar 4.

 */
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n5. Simulate ICA Queue"
                    + "\n"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        TestQueue();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
             * 
             * 
             * 
             *  2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
             *  S: Var 4:e element man lägger till inkl det första.
             *  
                3. Med hur mycket ökar kapaciteten?
                S: Arrayen ökar med 4 positioner varje gång.

                4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
                S: För att spara prestanda då det är kostsamt att skapa om en array och behålla värdena i den.

                5. Minskar kapaciteten när element tas bort ur listan?
                S: Nej

                6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
                S: När minnesanvändning är kritisk, eller om man vill använda värdena för beräkningar så underlättar arrayer
            */
            bool doLoop = true;

            List<string> theList = new List<string>();
 
            while (doLoop) {

                Console.Clear();
                Console.WriteLine("Type +WordToAdd or -WordToRemove or 0 to Exit to Main Menu");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch(nav.ToString().ToLower())
                {
                    case "+":
                        theList.Add(value);
                        break;

                    case "-":
                        theList.Remove(value);
                        break;

                    case "0":
                        doLoop = false;
                        break;

                    default:
                        break;
                }

                if (doLoop)
                {
                    Console.WriteLine("TheList Capacity: " + theList.Capacity + ": " + String.Join(", ", theList));
                    Console.WriteLine(" ");
                    Console.WriteLine("Hit any key to continue...");
                    Console.ReadKey();
                }

            }



        }

        static void TestQueue()
        {
            /*
             1. Simulera följande kö:
                a. ICA öppnar och kön till kassan är tom
                b. Kalle ställer sig i kön
                c. Greta ställer sig i kön
                d. Kalle blir expedierad och lämnar kön
                e. Stina ställer sig i kön
                f. Greta blir expedierad och lämnar kön
                g. Olle ställer sig i kön
            */

            Console.Clear();
            Console.WriteLine("Queue Simulation. Press any key between each entry.");
            Console.WriteLine(" ");

            Queue<string> theQueue = new Queue<string>();

            List<string> queueFlow = new List<string> { "+Kalle", "&Gref", "+Greta", "-Kalle", "+Stina", "-Greta", "+Olle" };

            foreach (string flowEntry in queueFlow)
            {
                QueueEntry queueEntry = new QueueEntry(flowEntry);

                switch (queueEntry.QueueAction)
                {
                    case "+":
                        theQueue.Enqueue(queueEntry.QueueEntryLabel);
                        break;

                    case "-":
                        theQueue = theQueue.Dequeue(queueEntry.QueueEntryLabel);
                        break;
 
                    default:
                       
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine(" Entries in Queue Flow must start with + or - (Flow Entry: " + flowEntry + ") ");

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();

                        break;

                }

                Console.WriteLine("TheQueue Content: " + theQueue.Count + ": " + String.Join(", ", theQueue.ToArray()));
                Console.WriteLine(" ");
                Console.ReadKey();

            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            bool doLoop = true;

            Queue<string> theQueue = new Queue<string>();

            while (doLoop)
            {
                Console.Clear();
                Console.WriteLine("Type +PersonToAddToQueue or -PersonToRemoveFromQueue or 0 to Exit to Main Menu");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav.ToString().ToLower())
                {
                    case "+":
                        theQueue.Enqueue(value);
                        break;

                    case "-":
                        // Using Linq in Extension Method Dequeue in Class Extensions
                        theQueue = theQueue.Dequeue(value);
                        break;

                    case "0":
                        doLoop = false;
                        break;

                    default:
                        break;
                }

                if (doLoop)
                {
                    Console.WriteLine("TheQueue Content: " + theQueue.Count + ": " + String.Join(", ", theQueue.ToArray()));
                    Console.WriteLine(" ");
                    Console.WriteLine("Hit any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

