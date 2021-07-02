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

        public static Stack<string> Pop(this Stack<string> stack, String valueToRemove)
        {
            return new Stack<string>(stack.Where(x => x != valueToRemove));
        }

        // Returns the string as reversed
        public static string ToReverseString(this string input)
        {
            char[] inputArray = input.ToCharArray();
            int size = inputArray.Length;

            Stack<string> inputStack = new Stack<string>(size);

            for (int i = 0; i < size; ++i)
            {
                inputStack.Push(inputArray[i].ToString());
            }

            string[] outputArray = inputStack.ToArray();

            return String.Join("", outputArray);
        }
        
        // Verify that a string is Parenthesis Balanced so that all Right Hand Parenthesises match their Left counterpart
        public static Boolean IsBalanced(this string input)
        {
            List<string> leftPars = new List<string>() { "(", "[", "{" };
            List<string> rightPars = new List<string>() { ")", "]", "}" };
  
            bool result = true;
            char[] inputArray = input.ToCharArray();
            int size = inputArray.Length;

            Stack<string> inputStack = new Stack<string>();

            for (int i = 0; i < size; ++i)
            {
                string inputCharacter = inputArray[i].ToString();

                // If the char is one of the left parenthesises, Push to Stack
                if (leftPars.Contains(inputCharacter))
                {
                    inputStack.Push(inputCharacter);
                }
                else if (rightPars.Contains(inputCharacter)) // Else if it's a right parenthesis...
                {
                    // Make sure there is at least one right parenthesis to match against, otherwise its not balanaced
                    if (inputStack.Count == 0)
                    {
                        result = false;
                        break;
                    }

                    // Pop last one from Stack
                    string popedCharacter = inputStack.Pop();

                    // Get the index of the right parenthesis to be able to find its counterpart in the left parenthesises
                    int rightIndex = rightPars.IndexOf(inputCharacter);

                    // Verify that the input characters corresponding left parenthesis matches the last found right parenthesis
                    if (popedCharacter != leftPars[rightIndex])
                    {
                        // If not, the string is not Balanced
                        result = false;
                        break;
                    }
                }
                 
            }

            // All chars in string verified, check that all parenthesises has been matched, else it's not a balanced string
            if (inputStack.Count != 0)
            {
                result = false;
            }

            return result;
        }

        public static string Right(this string source, int right_length)
        {
            if (right_length >= source.Length)
                return source;
            return source.Substring(source.Length - right_length);
        }

    }
}
