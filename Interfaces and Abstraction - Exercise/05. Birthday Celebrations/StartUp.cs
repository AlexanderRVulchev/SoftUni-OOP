using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Birthday_Celebrations
{
    public class StartUp
    {
        static void Main()
        {
            List<IBirthdatable> humansAndPets = new List<IBirthdatable>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmd = input.Split();
                if (cmd[0] == "Citizen")                
                    humansAndPets.Add(new Citizen(cmd[1], int.Parse(cmd[2]), cmd[3], cmd[4]));                
                else if (cmd[0] == "Pet")                
                    humansAndPets.Add(new Pet(cmd[1], cmd[2]));
                // We don't need robots
            }
            string targetYear = Console.ReadLine();
            IEnumerable<string> filteredBirthdates = humansAndPets
                .Where(x => x.BirthYearOnly == targetYear)
                .Select(x => x.BirthDate);

            if (filteredBirthdates.Any())
                Console.WriteLine(String.Join(Environment.NewLine, filteredBirthdates));
        }
    }
}