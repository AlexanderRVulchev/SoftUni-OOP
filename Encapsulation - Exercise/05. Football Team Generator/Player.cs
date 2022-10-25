using System;


namespace _05._Football_Team_Generator
{
    public class Player
    {
        // Fields
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

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

        public int Endurance
        {
            get { return endurance; }
            set { if (StatIsValid("Endurance", value)) endurance = value; }
        }

        public int Sprint
        {
            get { return sprint; }
            set { if (StatIsValid("Sprint", value)) sprint = value; }
        }

        public int Dribble
        {
            get { return dribble; }
            set { if (StatIsValid("Dribble", value)) dribble = value; }
        }

        public int Passing
        {
            get { return passing; }
            set { if (StatIsValid("Passing", value)) passing = value; }
        }

        public int Shooting
        {
            get { return shooting; }
            set { if (StatIsValid("Shooting", value)) shooting = value; }
        }

        public int SkillLevel
        { get => (int)Math.Round((double)(this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0d); }

        // Constructors
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        // Methods
        private bool StatIsValid(string statName, int statValue)
        {
            if (statValue >= 0 && statValue <= 100)
                return true;
            else
                throw new ArgumentException($"{statName} should be between 0 and 100.");            
        }
    }
}
