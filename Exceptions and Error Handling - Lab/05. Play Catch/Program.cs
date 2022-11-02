//You will receive on the first line an array of integers.
//After that you will receive commands, which should manipulate the array:
//•	"Replace {index} {element}" – Replace the element at the given index with the given element. 
//•	"Print {startIndex} {endIndex}" – Print the elements from the start index to the end index inclusive.
//•	"Show {index}" – Print the element at the index.
//You have the task to rewrite the messages from the exceptions which can be produced from your program:
//•	If you receive an index, which does not exist in the array print:
//"The index does not exist!"
//•	If you receive a variable, which is of invalid type:
//"The variable is not in the correct format!"
// When you catch 3 exceptions – stop the input and print the elements of the array separated with ", ".


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main()
        {
            int[] intArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int exceptionsCount = 0;
            while (exceptionsCount < 3)
            {
                string[] cmd = Console.ReadLine().Split();
                try
                {
                    switch (cmd[0])
                    {
                        case "Replace": Replace(intArray, int.Parse(cmd[1]), int.Parse(cmd[2])); break;
                        case "Print": Print(intArray, int.Parse(cmd[1]), int.Parse(cmd[2])); break;
                        case "Show": Show(intArray, int.Parse(cmd[1])); break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCount++;
                }
            }
            Console.WriteLine(String.Join(", ", intArray));
        }

        static void Replace(int[] intArray, int index, int element)
        { intArray[index] = element; }
        
        static void Print(int[] intArray, int start, int end)
        {
            Queue<int> intElements = new Queue<int>();
            for (int i = start; i <= end; i++)            
                intElements.Enqueue(intArray[i]);
            Console.WriteLine(String.Join(", ", intElements));            
        }

        static void Show(int[] intArray, int index)
        { Console.WriteLine(intArray[index]); }
    }
}
