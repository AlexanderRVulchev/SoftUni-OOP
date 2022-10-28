using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Border_Control
{
    public class Citizen : IIdentifiable
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public void CheckId(string fakeSubstring)
        {
            if (this.Id.EndsWith(fakeSubstring))
                Console.WriteLine(this.Id);
        }
    }
}
