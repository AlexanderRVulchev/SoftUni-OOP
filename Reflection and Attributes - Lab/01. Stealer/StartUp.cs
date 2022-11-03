//NOTE: You need a public StartUp class with the namespace Stealer.
//Add the Hacker class from the box below to your project.

//There is the one nasty hacker, but not so wise though.
//He is trying to steal a big amount of money and transfer it to his account.
//The police are after him but they need a professional… Correct - this is you!
//You have the information that this hacker is keeping some of his info in private fields.
//Create a new class named Spy and add inside a method called - StealFieldInfo, which receives:
//•	string – the name of the class to investigate
//•	an array of string - names of the fields to investigate
//After finding the fields, you must print on the console:
//"Class under investigation: {nameOfTheClass}"
//On the next lines, print info about each field in the following format:
//"{filedName} = {fieldValue}"
//Use StringBuilder to concatenate the answer.Don’t change anything in Hacker class!

using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}
