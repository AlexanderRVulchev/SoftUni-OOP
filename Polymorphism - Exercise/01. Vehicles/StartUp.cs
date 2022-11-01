using System;
using System.Linq;

namespace _01._Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            string[] truckInfo = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                string type = tokens[1];
                double value = double.Parse(tokens[2]);

                if (command == "Drive")
                {
                    if (type == "Car")
                        car.Drive(value);
                    else if (type == "Truck")
                        truck.Drive(value);
                }
                else if (command == "Refuel")
                {
                    if (type == "Car")
                        car.Refuel(value);
                    else if (type == "Truck")
                        truck.Refuel(value);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
