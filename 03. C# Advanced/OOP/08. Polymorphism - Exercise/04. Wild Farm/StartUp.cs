using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class StartUp
    {
        static void Main()
        {
            string cmd = Console.ReadLine();
            List<Animal> farm = new List<Animal>();
            while (cmd != "End")
            {
                string[] food = Console.ReadLine().Split();
                string[] cmdToArray = cmd.Split();
                switch (cmdToArray[0])
                {
                    case "Hen":
                        farm.Add(new Hen(cmdToArray[1], double.Parse(cmdToArray[2]), double.Parse(cmdToArray[3])));
                        farm.LastOrDefault().Eat(CreateFoodByInput(food));
                        break;
                    case "Owl":
                        farm.Add(new Owl(cmdToArray[1], double.Parse(cmdToArray[2]), double.Parse(cmdToArray[3])));
                        farm.LastOrDefault().Eat(CreateFoodByInput(food));
                        break;
                    case "Mouse":
                        farm.Add(new Mouse(cmdToArray[1], double.Parse(cmdToArray[2]), cmdToArray[3]));
                        farm.LastOrDefault().Eat(CreateFoodByInput(food));
                        break;
                    case "Cat":
                        farm.Add(new Cat(cmdToArray[1], double.Parse(cmdToArray[2]), cmdToArray[3], cmdToArray[4]));
                        farm.LastOrDefault().Eat(CreateFoodByInput(food));
                        break;
                    case "Dog":
                        farm.Add(new Dog(cmdToArray[1], double.Parse(cmdToArray[2]), cmdToArray[3]));
                        farm.LastOrDefault().Eat(CreateFoodByInput(food));
                        break;
                    case "Tiger":
                        farm.Add(new Tiger(cmdToArray[1], double.Parse(cmdToArray[2]), cmdToArray[3], cmdToArray[4]));
                        farm.LastOrDefault().Eat(CreateFoodByInput(food));
                        break;
                }
                cmd = Console.ReadLine();
            }
            foreach (var animal in farm)
            {
                Console.WriteLine(animal);
            }
        }
        static Food CreateFoodByInput(string[] food)
        {
            if (food[0] == "Vegetable")
            {
                return new Vegetable(int.Parse(food[1]));
            }
            else if (food[0] == "Meat")
            {
                return new Meat(int.Parse(food[1]));
            }
            else if (food[0] == "Fruit")
            {
                return new Fruit(int.Parse(food[1]));
            }
            else
            {
                return new Seeds(int.Parse(food[1]));
            }
        }
    }
}
