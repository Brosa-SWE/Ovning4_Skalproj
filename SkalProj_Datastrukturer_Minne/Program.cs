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
                    + "\n4. CheckParanthesis()"
                    + "\n5. TestQueue() - Simulate ICA Queue"
                    + "\n6. ReverseText()"
                    + "\n7. RecursiveOdd()"
                    + "\n8. RecursiveEven()"
                    + "\n9. RecursiveFibonacci()"
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
                    case '6':
                        ReverseText();
                        break;
                    case '7':
                        RecursiveOdd();
                        break;
                    case '8':
                        RecursiveEven();
                        break;
                    case '9':
                        RecursiveFibonacci();
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

            while (doLoop)
            {

                Console.Clear();
                Console.WriteLine("Type +WordToAdd or -WordToRemove or 0 to Exit to Main Menu");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav.ToString().ToLower())
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
                Entry queueEntry = new Entry(flowEntry);

                switch (queueEntry.Action)
                {
                    case "+":
                        theQueue.Enqueue(queueEntry.EntryValue);
                        break;

                    case "-":
                        // theQueue.Dequeue() // Standard: Remove the first entry in the Queue
                        theQueue = theQueue.Dequeue(queueEntry.EntryValue); // Extension: Remove any entry in the Queue
                        break;

                    default:
                        break;

                }
                Console.WriteLine(" ");
                Console.Write($"{queueEntry.EntryStory}. --- Kön ser nu ut så här: {String.Join(", ", theQueue.ToArray())}");
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
                    Console.WriteLine($"TheQueue Content: {theQueue.Count} entries: {String.Join(", ", theQueue.ToArray())}");
                    Console.WriteLine(" ");
                    Console.WriteLine("Hit any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        /*
         * 
         * 2.   Implementera en ReverseText-metod som läser in en sträng från användaren och
                med hjälp av en stack vänder ordning på teckenföljden för att sedan skriva ut
                den omvända strängen till användaren.
        */
        static void ReverseText()
        {
            bool doLoop = true;

            Stack<string> theStack = new Stack<string>();

            while (doLoop)
            {
                Console.Clear();
                Console.WriteLine("Type the text you want reversed or 0 to Exit to Main Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        doLoop = false;
                        break;

                    default:
                        Console.WriteLine($"Reversed: {input.ToReverseString()}");
                        break;
                }

                if (doLoop)
                {
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
             * 
             * 1.   Varför är det inte så smart att använda en stack i det här fallet?
             * S:   För att det inte alltid är den senast tillagda personen i kön som ska tas bort vilket gör att man
             *      får skriva kod runt det problemet
             * 
            */

            bool doLoop = true;

            Stack<string> theStack = new Stack<string>();

            while (doLoop)
            {
                Console.Clear();
                Console.WriteLine("Type +PersonToAddToStack or -PersonToRemoveFromStack or 0 to Exit to Main Menu");

                Entry Entry = new Entry(Console.ReadLine());

                switch (Entry.Action)
                {
                    case "+":
                        theStack.Push(Entry.EntryValue);
                        break;

                    case "-":
                        // Using Linq in Extension Method Pop in Class Extensions
                        theStack = theStack.Pop(Entry.EntryValue);
                        break;

                    case "0":
                        doLoop = false;
                        break;

                    default:
                        break;
                }

                if (doLoop)
                {
                    Console.WriteLine($"TheStack Content: {String.Join(", ", theStack.ToArray())}");
                    Console.WriteLine(" ");
                    Console.WriteLine("Hit any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            bool doLoop = true;

            while (doLoop)
            {
                Console.Clear();
                Console.WriteLine("Type the text you want to check for Parenthesis Balanced or 0 to Exit to Main Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        doLoop = false;
                        break;

                    default:
                        if (input.IsBalanced())
                        {
                            Console.WriteLine("The string IS Parenthesis Balanced");
                        }
                        else
                        {
                            Console.WriteLine("Ths string is NOT Parenthesis Balanaced");
                        }

                        break;
                }

                if (doLoop)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Hit any key to continue...");
                    Console.ReadKey();
                }
            }
        }

 
        static void RecursiveOdd()
        {
            int inputInt;
            int resultInt;

            bool doLoop = true;

            while (doLoop)
            {
                Console.Clear();
                Console.WriteLine("Type the integer you want to test RecursiveOdd() for or 0 to Exit to Main Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        doLoop = false;
                        break;

                    default:
                        if (!int.TryParse(input, out inputInt))
                        {
                            Console.WriteLine("You must input an Integer value.");
                            break;
                        }

                        resultInt = FindNthOdd(inputInt);

                        Console.WriteLine($"The {inputInt}{GetNthEnding(inputInt)} ODD Number is {resultInt} (1 is not counted)");


                        break;
                }

                if (doLoop)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Hit any key to continue...");
                    Console.ReadKey();
                }
            }

        }

        static int FindNthOdd(int inputInt)
        {

            if (inputInt == 0)
            {
                return 1;
            }

            return (FindNthOdd(inputInt - 1) + 2);

        }

        static void RecursiveEven()
        {
            int inputInt;
            int resultInt;

            bool doLoop = true;

            while (doLoop)
            {
                Console.Clear();
                Console.WriteLine("Type the integer you want to test RecursiveEven() for or 0 to Exit to Main Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        doLoop = false;
                        break;

                    default:
                        if (!int.TryParse(input, out inputInt))
                        {
                            Console.WriteLine("You must input an Integer value.");
                            break;
                        }

                        resultInt = FindNthEven(inputInt);

                        Console.WriteLine($"The {inputInt}{GetNthEnding(inputInt)} EVEN Number is {resultInt}");


                        break;
                }

                if (doLoop)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Hit any key to continue...");
                    Console.ReadKey();
                }
            }

        }

        static int FindNthEven(int inputInt)
        {
            Console.WriteLine("In " + inputInt);

            if (inputInt > 20)
            {
                Environment.Exit(0);
            }


            if (inputInt == 0)
            {
                return 1;
            }

            return (FindNthEven(inputInt) + 1);

        }

        static void RecursiveFibonacci()
        {
            int inputInt;
            int resultInt;

            bool doLoop = true;

            while (doLoop)
            {
                Console.Clear();
                Console.WriteLine("Enter what n'th FIBONACCI Number you want or 0 to Exit to Main Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        doLoop = false;
                        break;

                    default:
                        if (!int.TryParse(input, out inputInt))
                        {
                            Console.WriteLine("You must input an Integer value.");
                            break;
                        }

                        if (inputInt > 30)
                        {
                            Console.WriteLine("Try with a smaller number, this will take too long to calculate...");
                            break;
                        }
                        resultInt = FindNthFibonacciNumber(inputInt);

                        Console.WriteLine($"The {inputInt}{GetNthEnding(inputInt)} FIBONACCI Number is {resultInt}");

                        break;
                }

                if (doLoop)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Hit any key to continue...");
                    Console.ReadKey();
                }
            }

        }


        static int FindNthFibonacciNumber(int n)
        {

            if (n == 1 || n == 2) return 1;

            int nthfibonacciNumber = FindNthFibonacciNumber(n - 1) + FindNthFibonacciNumber(n - 2);
            return nthfibonacciNumber;
        }


        static string GetNthEnding(int inputInt)
        {
            switch (inputInt) {
                case 0:
                    return "";


                case 1:
                    return "'st";

                case 2:
                    return "'nd";

                case 3:
                    return "'rd";

                default:
                    return "'th";
            }
        }


    }
}