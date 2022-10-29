using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Military_Elite
{
    public class Mission
    {
        string CodeName { get; set; }
        string State { get; set; }

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        => $"Code Name: {this.CodeName} State: {this.State}";
    }
}
