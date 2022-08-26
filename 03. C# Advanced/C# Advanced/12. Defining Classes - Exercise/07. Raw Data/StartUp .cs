using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> allCars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string model = input.Split()[0];
                int engineSpeed = int.Parse(input.Split()[1]);
                int enginePower = int.Parse(input.Split()[2]);
                int cargoWeight = int.Parse(input.Split()[3]);
                string cargoType = input.Split()[4];
                double tire1Pressure = double.Parse(input.Split()[5]);
                int tire1Age = int.Parse(input.Split()[6]);
                double tire2Pressure = double.Parse(input.Split()[7]);
                int tire2Age = int.Parse(input.Split()[8]);
                double tire3Pressure = double.Parse(input.Split()[9]);
                int tire3Age = int.Parse(input.Split()[10]);
                double tire4Pressure = double.Parse(input.Split()[11]);
                int tire4Age = int.Parse(input.Split()[12]);

                allCars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, 
                tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age));
            }
            string cmd = Console.ReadLine();
            if (cmd == "fragile")
            {
                foreach (var car in allCars)
                {
                    bool isFragile = false;
                    foreach (var tire in car.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            isFragile = true;
                            break;
                        }
                    }
                    if (car.Cargo.Type == "fragile" && isFragile)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (cmd == "flammable")
            {
                foreach (var car in allCars)
                {
                    if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
