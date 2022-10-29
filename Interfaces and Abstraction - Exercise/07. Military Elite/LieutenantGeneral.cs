using _07._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Military_Elite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<Private> Privates { get; set; }

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, params Private[] privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<Private>(privates);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Privates:");
            if (this.Privates.Any())
                sb.Append(string.Join(Environment.NewLine, this.Privates.Select(x => $"  {x}")));
            return sb.ToString().TrimEnd();
        }
    }
}