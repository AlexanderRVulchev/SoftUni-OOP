

namespace _09._Explicit_Interfaces
{
    public interface IResident
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public string GetName();
    }
}
