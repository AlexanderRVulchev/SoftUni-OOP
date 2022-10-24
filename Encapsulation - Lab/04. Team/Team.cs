using System;
using System.Collections.Generic;


namespace PersonsInfo
{
    public class Team
    {
        // Fields
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        // Properties
        public string Name { get { return name; } set { name = value; } }
        public IReadOnlyCollection<Person> FirstTeam { get { return firstTeam.AsReadOnly(); } }
        public IReadOnlyCollection<Person> ReserveTeam { get { return reserveTeam.AsReadOnly(); } }

        // Constructors
        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        // Methods        
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
                this.firstTeam.Add(person);
            else
                this.reserveTeam.Add(person);
        }
    }
}
