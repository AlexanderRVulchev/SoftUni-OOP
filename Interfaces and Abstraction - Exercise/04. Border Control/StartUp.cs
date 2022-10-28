using System;
using System.Collections.Generic;

namespace _04._Border_Control
{
    public class StartUp
    {
        static void Main()
        {
            List<IIdentifiable> entities = new List<IIdentifiable>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmd = input.Split();
                if (cmd.Length == 2)
                {
                    string name = cmd[0];
                    string id = cmd[1];
                    entities.Add(new Robot(name, id));
                }
                else if (cmd.Length == 3)
                {
                    string name = cmd[0];
                    int age = int.Parse(cmd[1]);
                    string id = cmd[2];
                    entities.Add(new Citizen(name, age, id));
                }
            }
            string fakeSubstring = Console.ReadLine();

            foreach (IIdentifiable entity in entities)
                entity.CheckId(fakeSubstring);
        }
    }
}
