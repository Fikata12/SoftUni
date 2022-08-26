using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialCars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Tire[]> allTires = new List<Tire[]>();
            while (input != "No more tires")
            {
                string[] currentTires = input.Split().ToArray();
                allTires.Add(new Tire[4]
                {
                    new Tire(int.Parse(currentTires[0]), double.Parse(currentTires[1])),
                    new Tire(int.Parse(currentTires[2]), double.Parse(currentTires[3])),
                    new Tire(int.Parse(currentTires[4]), double.Parse(currentTires[5])),
                    new Tire(int.Parse(currentTires[6]), double.Parse(currentTires[7]))
                });
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            List<Engine> allEngines = new List<Engine>();
            while (input != "Engines done")
            {
                string[] currentEngine = input.Split().ToArray();
                allEngines.Add(new Engine(int.Parse(currentEngine[0]), double.Parse(currentEngine[1])));
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            List<Car> allCars = new List<Car>();
            while (input != "Show special")
            {
                string[] currentCar = input.Split().ToArray();
                allCars.Add(new Car(currentCar[0], currentCar[1], int.Parse(currentCar[2]), double.Parse(currentCar[3]), double.Parse(currentCar[4]), allEngines[0], allTires[0]));
                allEngines.RemoveAt(0);
                allTires.RemoveAt(0);
                input = Console.ReadLine();
            }
            List<Car> specialCars = new List<Car>();
            foreach (var car in allCars)
            {
                double sumPressures = car.Tires[0].Pressure + car.Tires[1].Pressure + car.Tires[2].Pressure + car.Tires[3].Pressure;
                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && sumPressures > 9 && sumPressures < 10)
                {
                    car.FuelQuantity -= car.FuelConsumption / 100 * 20;
                    specialCars.Add(car);
                }
            }
            foreach (var specialCar in specialCars)
            {
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }
    }
}

