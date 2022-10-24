
namespace PersonsInfo
{
    public class Person
    {
        // Fields
        private string firstName;
        private string lastName;
        private int age;

        // Properties
        public string FirstName { get { return firstName; } private set { firstName = value; } }
        public string LastName { get { return lastName; } private set { lastName = value; } }
        public int Age { get { return age; } private set { age = value; } }

        // Constructors
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        // Methods
        public override string ToString()
        => $"{this.firstName} {this.lastName} is {this.age} years old.";
    }
}