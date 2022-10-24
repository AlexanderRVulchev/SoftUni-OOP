
namespace PersonsInfo
{
    public class Person
    {
        // Fields
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;        

        // Properties
        public string FirstName { get { return firstName; } private set { firstName = value; } }
        public string LastName { get { return lastName; } private set { lastName = value; } }
        public int Age { get { return age; } private set { age = value; } }
        public decimal Salary { get { return salary; } private set { salary = value; } }        

        // Constructors
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        // Methods
        public override string ToString()
        => $"{this.firstName} {this.lastName} receives {this.salary:f2} leva.";

        public void IncreaseSalary(decimal percentage)
        {
            if (this.age > 30)
                this.salary += this.salary * percentage / 100;
            else
                this.salary += this.salary * percentage / 200;
        }
    }
}