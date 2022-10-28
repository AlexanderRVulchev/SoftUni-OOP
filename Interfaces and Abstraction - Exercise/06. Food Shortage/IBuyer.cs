

namespace _06._Food_Shortage
{
    public interface IBuyer
    {
        int Food { get; set; }
        string Name { get; set; }
        void BuyFood();
    }
}
