
namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }
        public string Id { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Age = age;
            this.Name = name;
            this.Id = id;
            this.Birthdate = birthdate;
        }
    }
}
