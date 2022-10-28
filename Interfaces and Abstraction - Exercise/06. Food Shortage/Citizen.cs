
namespace _06._Food_Shortage
{
    public class Citizen : IBuyer
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public string BirthDate { get; set; }
        public int Food { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
            this.BirthDate = birthdate;
            this.Food = 0;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
