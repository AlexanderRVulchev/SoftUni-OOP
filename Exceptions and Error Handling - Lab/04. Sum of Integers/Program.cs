//You will receive a sequence of elements of different types, separated by space.
//Your task is to calculate the sum of all valid integer numbers in the input.
//Try to add each element of the array to the sum
//and write messages for the possible exceptions while processing the element:
//•	If you receive an element, which is not in the correct format (FormatException):
//"The element '{element}' is in wrong format!"
//•	If you receive an element, which is out of the integer type range (OverflowException):
//"The element '{element}' is out of range!"
//After each processed element add the following message:
//	"Element '{element}' processed - current sum: {sum}"
//At the end print the total sum of all integers:
//	"The total sum of all integers is: {sum}"


using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Sum_of_Integers
{
    internal class Program
    {
        static void Main()
        {            
            int sum = 0;
            string input = Console.ReadLine();
            Queue<string> elements = new Queue<string>(input.Split());
            while (elements.Any())
            {
                int number = 0;
                string element = elements.Dequeue();

                try
                { number = int.Parse(element); }
                catch (FormatException)
                { Console.WriteLine($"The element '{element}' is in wrong format!"); }
                catch (OverflowException)
                { Console.WriteLine($"The element '{element}' is out of range!"); }

                sum += number;
                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
