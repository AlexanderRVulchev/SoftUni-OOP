using _07._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Military_Elite
{
    public class StartUp
    {
        static void Main()
        {

            List<Private> privates = new List<Private>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                Soldier soldier = null;
                string[] cmd = input.Split();
                switch (cmd[0])
                {
                    case "Private":
                        soldier = new Private(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]));
                        privates.Add(new Private(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4])));
                        break;
                    case "LieutenantGeneral":
                        string[] privateIDs = cmd.Skip(5).ToArray();
                        List<Private> newPrivates = new List<Private>();
                        for (int i = 0; i < privateIDs.Length; i++)
                        {
                            if (privates.Any(s => s.Id == privateIDs[i]))
                                newPrivates.Add(privates.Find(s => s.Id == privateIDs[i]));
                        }
                        soldier = new LieutenantGeneral(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]), newPrivates.ToArray());
                        break;
                    case "Engineer":
                        try
                        {
                            string[] repairInfo = cmd.Skip(6).ToArray();
                            soldier = new Engineer(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]), cmd[5], repairInfo);
                        }
                        catch (ArgumentException) { continue; }
                        break;
                    case "Commando":
                        try
                        {
                            string[] missionInfo = cmd.Skip(6).ToArray();
                            soldier = new Commando(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]), cmd[5], missionInfo);
                        }
                        catch (ArgumentException) { continue; }
                        break;
                    case "Spy":
                        soldier = new Spy(cmd[1], cmd[2], cmd[3], int.Parse(cmd[4]));
                        break;
                }
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
