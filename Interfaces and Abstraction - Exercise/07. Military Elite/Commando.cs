using _07._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Military_Elite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public List<Mission> Missions { get; set; }

        public Commando(string id, string firstName, string lastName, decimal salary, string corps, params string[] missionInfo)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
            for (int i = 0; i < missionInfo.Length; i += 2)
            {
                string missionName = missionInfo[i];
                string missionState = missionInfo[i + 1];
                if (missionState == "inProgress" || missionState == "Finished")
                    this.Missions.Add(new Mission(missionName, missionState));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");
            if (this.Missions.Any())
               sb.Append(String.Join(Environment.NewLine, this.Missions.Select(x => $"  {x}")));
            return sb.ToString().TrimEnd();
        }
    }
}
