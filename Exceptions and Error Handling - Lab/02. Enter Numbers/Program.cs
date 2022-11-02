//Write a method ReadNumber(int start, int end) that enters an integer number in a given range (start…end),
//excluding the numbers start and end. If an invalid number or a non-number text is entered,
//the method should throw an exception. Using this method write a program that enters 10 numbers:
//a1, a2, … a10, such that 1 < a1 < … < a10 < 100.
//If the user enters an invalid number, continue while there are 10 valid numbers entered.
//Print the array elements, separated with comma and space “, ”.
//Hints
//•	When the entered input holds a non-integer value, print “Invalid Number!”
//•	When the entered input holds an integer that is out of range,
//print "Your number is not in range {currentNumber} - 100!"


using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Enter_Numbers
{
    internal class Program
    {
        static void Main()
        {
            List<int> numsCollection = new List<int>();
            while (numsCollection.Count < 10)
            {
                try
                {
                    if (!numsCollection.Any())
                        numsCollection.Add(ReadNumber(1, 100));
                    else
                        numsCollection.Add(ReadNumber(numsCollection.Max(), 100));
                }
                catch (FormatException formatEx)
                { Console.WriteLine(formatEx.Message); }
                catch (ArgumentException argEx)
                { Console.WriteLine(argEx.Message); }
            }
            Console.WriteLine(String.Join(", ", numsCollection));
        }

        static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int num;
            try
            { num = int.Parse(input); }
            catch (FormatException)
            { throw new FormatException("Invalid Number!"); }

            if (num <= start || num >= end)
            { throw new ArgumentException($"Your number is not in range {start} - {end}!"); }

            return num;
        }
    }
}
