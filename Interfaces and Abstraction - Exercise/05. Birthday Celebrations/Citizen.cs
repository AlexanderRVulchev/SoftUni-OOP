using System.Linq;


namespace _05._Birthday_Celebrations
{
    public class Citizen : IBirthdatable
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public string BirthDate { get; set; }
        public string BirthYearOnly => this.BirthDate.Split('/').Last();

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
            this.BirthDate = birthdate;
        }

    }
}
