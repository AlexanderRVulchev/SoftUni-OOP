using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Military_Elite
{
    public class Repair
    {
        public string PartName { get; set; }
        public int HoursWorked { get; set; }

        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }

        public override string ToString()
        => $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
    }
}