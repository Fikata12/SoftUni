using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> listEngines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = input[0];
                int power = int.Parse(input[1]);
                if (input.Length == 2)
                {
                    listEngines.Add(new Engine(model, power));
                }
                else if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int displacement))
                    {
                        listEngines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        listEngines.Add(new Engine(model, power, input[2]));
                    }
                }
                else if (input.Length == 4)
                {
                    listEngines.Add(new Engine(model, power, int.Parse(input[2]), input[3]));
                }
            }
            int m = int.Parse(Console.ReadLine());
            List<Car> listCars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = input[0];
                string engine = input[1];

                foreach (var item in listEngines)
                {
                    if (item.Model == engine)
                    {
                        listCars.Add(new Car(model, item));
                        break;
                    }
                }
                if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int weight))
                    {
                        listCars[i].Weight = weight;
                    }

                    else
                    {
                        listCars[i].Color = input[2];
                    }

                }
                else if (input.Length == 4)
                {
                    listCars[i].Weight = int.Parse(input[2]);
                    listCars[i].Color = input[3];
                }
            }
            foreach (var car in listCars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
