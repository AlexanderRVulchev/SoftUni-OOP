//NOTE: You need a public StartUp class with the namespace Stealer.
//It’s time to see what this hacker you are dealing with aims to do.
//Create a method inside your Spy class called - RevealPrivateMethods(string className).
//Print all private methods in the following format:
//All Private Methods of Class: {className
//}
//Base Class: { baseClassName}
//On the next lines, print found method’s names each on a new line.
//Use StringBuilder to concatenate the answer.
//Don’t change anything in Hacker class!In your Main() method,
//you should be able to check your program with the current piece of code.



using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
