

namespace _09._Explicit_Interfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }

        public string GetName();
    }
}
