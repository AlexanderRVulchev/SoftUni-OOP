using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Food_Shortage
{
    public class StartUp
    {
        static void Main()
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int numberOfEntries = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEntries; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                if (cmd.Length == 4)
                    buyers.Add(new Citizen(cmd[0], int.Parse(cmd[1]), cmd[2], cmd[3]));
                else if (cmd.Length == 3)
                    buyers.Add(new Rebel(cmd[0], int.Parse(cmd[1]), cmd[2]));
            }
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (buyers.Any(b => b.Name == input))
                {
                    IBuyer buyer = buyers.Find(b => b.Name == input);
                    buyer.BuyFood();
                }
            }
            Console.WriteLine(buyers.Select(b => b.Food).Sum());
        }
    }
}
