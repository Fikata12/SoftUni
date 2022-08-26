using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
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
                string currModel = input.Split()[0];
                double currFuelAmount = double.Parse(input.Split()[1]);
                double currFuelConsumptionPerKilometer = double.Parse(input.Split()[2]);
                allCars.Add(new Car(currModel, currFuelAmount, currFuelConsumptionPerKilometer));
            }
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string currCarModel = cmd.Split()[1];
                double currAmountOfKm = double.Parse(cmd.Split()[2]);
                foreach (var car in allCars)
                {
                    if (car.Model == currCarModel)
                    {
                        car.Drive(car, currAmountOfKm);
                    }
                }
                cmd = Console.ReadLine();
            }
            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
