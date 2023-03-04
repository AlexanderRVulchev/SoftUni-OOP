//Expand Person with proper validation for every field:
//•	Name must be at least 3 symbols
//•	Age must not be zero or negative
//•	Salary can't be less than 460 (decimal)
//If some of the properties are NOT valid throw ArgumentExeption with the following messages:
//•	"Age cannot be zero or a negative integer!"
//•	"First name cannot contain fewer than 3 symbols!"
//•	"Last name cannot contain fewer than 3 symbols!"
//•	"Salary cannot be less than 650 leva!"


using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        decimal.Parse(cmdArgs[3]));

                persons.Add(person);
            }
            var parcentage = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));

        }
    }
}
