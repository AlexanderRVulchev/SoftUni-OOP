//Write a program that reads an integer number and calculates and prints its square root. 
//•	If the number is negative, print "Invalid number."
//•	In all cases finally, print "Goodbye."
//Use try-catch-finally.

using System;

namespace _01._Square_Root
{
    internal class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            try
            {
                if (num < 0)
                    throw new ArgumentException("Invalid number.");
                else
                    Console.WriteLine(Math.Sqrt(num));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
