using _07._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _07._Military_Elite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<Repair> Repairs { get; set; }

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, string[] repairInfo)
            : base(id, firstName, lastName, salary, corps)
        {
            List<Repair> repairs = new List<Repair>();
            for (int i = 0; i < repairInfo.Length; i += 2)
            {
                string repairPart = repairInfo[i];
                int repairHours = int.Parse(repairInfo[i + 1]);
                repairs.Add(new Repair(repairPart, repairHours));
            }
            this.Repairs = new List<Repair>(repairs);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");
            if (this.Repairs.Any())
                sb.Append(String.Join(Environment.NewLine, this.Repairs.Select(x => $"  {x}")));
            return sb.ToString().TrimEnd();
        }
    }
}