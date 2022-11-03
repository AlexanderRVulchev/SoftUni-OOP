//NOTE: You need a public StartUp class with the namespace Stealer.
//Use reflection to get all Hacker methods.Then prepare an algorithm that will recognize which methods are getters and setters.
//Print to console each getter on a new line in the format:
//"{name} will return {Return Type}"
//Then print all of the setters in the format:
//"{name} will set field of {Parameter Type}"
//Use StringBuilder to concatenate the answer.Don’t change anything in Hacker class!
//In your Main() method you should be able to check your program with the current piece of code.


using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
