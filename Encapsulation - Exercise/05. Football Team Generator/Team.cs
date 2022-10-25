using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Football_Team_Generator
{
    public class Team
    {
        // Fields
        private List<Player> players;
        private string name;

        // Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A name should not be empty.");
                else
                    name = value;
            }

        }

        public int Rating
        {
            get
            {
                if (this.players.Count > 0)
                    return (int)Math.Round(this.players.Select(x => x.SkillLevel).Average());
                else return 0;
            }
        }

        // Constructors
        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }

        // Methods
        public void AddPlayer(Player player)
        => this.players.Add(player);

        public void RemovePlayer(string playerName)
        {
            if (!this.players.Any(p => p.Name == playerName))
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            else
                this.players.Remove(this.players.Find(p => p.Name == playerName));
        }
    }
}