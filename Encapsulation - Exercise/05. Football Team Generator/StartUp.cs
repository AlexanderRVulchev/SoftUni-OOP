//A football Team has a variable number of players, a name, and a rating.
//A Player has a name and stats, which are the basis for his skill level.
//The stats a player has are endurance, sprint, dribble, passing, and shooting.
//Each stat can be an integer in the range [0..100].
//The overall skill level of a player is calculated as the average of his stats.
//Only the name of a player and his stats should be visible to the entire outside world.
//Everything else should be hidden.
//A Team should expose a name, a rating
//(calculated by the average skill level of all players in the team and rounded to the integer part only),
//and methods for adding and removing players.
//Your task is to model the Team and the Player classes following the proper principles of Encapsulation.
//Expose only the properties that need to be visible and validate data appropriately.
//Input
//Your application will receive commands until the "END" command is given.
//The command can be one of the following:
//•	"Team;{TeamName}" - add a new Team;
//•	"Add;{TeamName};{PlayerName};{Endurance};{Sprint};{Dribble};{Passing};{Shooting}" - add a new Player to the Team;
//•	"Remove;{TeamName};{PlayerName}" - remove the Player from the Team;
//•	"Rating;{TeamName}" - print the Team rating, rounded to an integer.
//Data Validation
//•	A name cannot be null, empty, or white space. If not, print "A name should not be empty."
//•	Stats should be in the range 0..100. If not, print "[Stat name] should be between 0 and 100."
//•	If you receive a command to remove a missing Player, print "Player [Player name] is not in [Team name] team."
//•	If you receive a command to add a Player to a missing Team, print "Team [team name] does not exist."
//•	If you receive a command to show stats for a missing Team, print "Team [team name] does not exist."


using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Football_Team_Generator
{
    internal class StartUp
    {
        static void Main()
        {
            List<Team> teams = new List<Team>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmd = input.Split(';');

                    if (cmd[0] == "Team")
                    {
                        teams.Add(new Team(cmd[1]));
                    }
                    else if (cmd[0] == "Add")
                    {
                        string teamName = cmd[1];
                        Team thisTeam = FindTeamIfItExists(teams, teamName);
                        Player thisPlayer = new Player(cmd[2], int.Parse(cmd[3]), int.Parse(cmd[4]), int.Parse(cmd[5]), int.Parse(cmd[6]), int.Parse(cmd[7]));
                        thisTeam.AddPlayer(thisPlayer);
                    }
                    else if (cmd[0] == "Remove")
                    {
                        string teamName = cmd[1];
                        Team thisTeam = FindTeamIfItExists(teams, teamName);
                        thisTeam.RemovePlayer(cmd[2]);
                    }
                    else if (cmd[0] == "Rating")
                    {
                        string teamName = cmd[1];
                        Team thisTeam = FindTeamIfItExists(teams, teamName);
                        Console.WriteLine($"{thisTeam.Name} - {thisTeam.Rating}");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static Team FindTeamIfItExists(List<Team> teams, string teamName)
        {
            if (!teams.Any(t => t.Name == teamName))
                throw new ArgumentException($"Team {teamName} does not exist.");
            return teams.Find(t => t.Name == teamName);
        }
    }
}
