using System;

namespace DominosProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create test arrays
            int[] arrayCorrectOrderedInputExpecting4 = new int[] { 1, 2, 3, 5, 6 };
            int[] arrayEmpty = new int[] { };
            int[] arrayCorrectUnorderedInputExpecting2 = new int[] { 6, 3, 4, 1, 5 };
            int[] arrayDuplicates = new int[] { 2, 1, 3, 3, 5 };
            int[] arrayNoMissingNumber = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] arrayMissingMultipleNumbers = new int[] { 1, 3, 4, 6 };
            int[] arrayNull = null;
            int[] arrayCorrectUnorderedInputExpecting11 = new int[] { 5, 2, 4, 14, 6, 7, 1, 9, 10, 12, 3, 8, 13 };

            // Using the function on test arrays
            Console.WriteLine(NumberFinder.FindMissingNumber(arrayCorrectOrderedInputExpecting4).Message);
            Console.WriteLine(NumberFinder.FindMissingNumber(arrayEmpty).Message);
            Console.WriteLine(NumberFinder.FindMissingNumber(arrayCorrectUnorderedInputExpecting2).Message);
            Console.WriteLine(NumberFinder.FindMissingNumber(arrayDuplicates).Message);
            Console.WriteLine(NumberFinder.FindMissingNumber(arrayNoMissingNumber).Message);
            Console.WriteLine(NumberFinder.FindMissingNumber(arrayMissingMultipleNumbers).Message);
            Console.WriteLine(NumberFinder.FindMissingNumber(arrayNull).Message);
            Console.WriteLine(NumberFinder.FindMissingNumber(arrayCorrectUnorderedInputExpecting11).Message);

            // Press the any key to close console window
            Console.ReadKey();
        }
    }
}