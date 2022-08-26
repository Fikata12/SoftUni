using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaInput = Console.ReadLine();
                string doughInput = Console.ReadLine();
                Dough dough = new Dough(doughInput.Split()[1], doughInput.Split()[2], double.Parse(doughInput.Split()[3]));
                Pizza pizza = new Pizza(pizzaInput.Split()[1], dough);
                string cmd = Console.ReadLine();
                while (cmd != "END")
                {
                    pizza.AddTopping(new Topping(cmd.Split()[1], double.Parse(cmd.Split()[2])));
                    cmd = Console.ReadLine();
                }
                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
