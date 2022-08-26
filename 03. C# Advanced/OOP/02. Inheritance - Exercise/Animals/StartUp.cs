using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string cmd = Console.ReadLine();
            while (cmd != "Beast!")
            {
                string animalInfo = Console.ReadLine();
                string name = animalInfo.Split()[0];
                int age = int.Parse(animalInfo.Split()[1]);
                string gender = animalInfo.Split()[2];
                if (name != "" && age > 0 && gender != "")
                {
                    switch (cmd)
                    {
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;
                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;
                        case "Frog":
                            animals.Add(new Frog(name, age, gender));
                            break;
                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));
                            break;
                        case "Kitten":
                            animals.Add(new Kitten(name, age));
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                cmd = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
