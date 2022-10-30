using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            Circle circle = new Circle(3);
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.Draw());
        }
    }
}
