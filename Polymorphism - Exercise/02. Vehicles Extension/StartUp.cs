using System;

namespace _02._Vehicles_Extension
{
    public class StartUp
    {
        static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            string[] truckInfo = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            string[] busInfo = Console.ReadLine().Split();
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                string type = tokens[1];
                double value = double.Parse(tokens[2]);

                if (command == "Drive")
                {
                    switch (type)
                    {
                        case "Car": car.Drive(value); break;
                        case "Truck": truck.Drive(value); break;
                        case "Bus": bus.Drive(value); break;
                    }
                }
                else if (command == "Refuel")
                {
                    switch(type)
                    {
                        case "Car": car.Refuel(value); break;
                        case "Truck": truck.Refuel(value); break;
                        case "Bus": bus.Refuel(value); break;
                    }
                }
                else if (command == "DriveEmpty")
                {
                    bus.DriveEmpty(value);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
