using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(input[3]), double.Parse(input[1]), double.Parse(input[2]));
            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(input[3]), double.Parse(input[1]), double.Parse(input[2]));
            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(input[3]), double.Parse(input[1]), double.Parse(input[2]));
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                if (cmd[0] == "Drive")
                {
                    if (cmd[1] == "Car")
                    {
                        car.Drive(double.Parse(cmd[2]));
                    }
                    else if (cmd[1] == "Truck")
                    {
                        truck.Drive(double.Parse(cmd[2]));
                    }
                    else if (cmd[1] == "Bus")
                    {
                        bus.Drive(double.Parse(cmd[2]));
                    }
                }
                else if (cmd[0] == "Refuel")
                {
                    if (cmd[1] == "Car")
                    {
                        car.Refuel(double.Parse(cmd[2]));
                    }
                    else if (cmd[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(cmd[2]));
                    }
                    else if (cmd[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(cmd[2]));
                    }
                }
                else if (cmd[0] == "DriveEmpty")
                {
                        bus.DriveEmpty(double.Parse(cmd[2]));
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
