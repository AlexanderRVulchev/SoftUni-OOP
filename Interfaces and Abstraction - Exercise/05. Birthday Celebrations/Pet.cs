using System.Linq;


namespace _05._Birthday_Celebrations
{
    public class Pet : IBirthdatable
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string BirthYearOnly => this.BirthDate.Split('/').Last();

        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }
    }
}
