using System;

namespace Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            double bpm = double.Parse(Console.ReadLine());
            double bmr = double.Parse(Console.ReadLine());
            double bvm = double.Parse(Console.ReadLine());
            Console.WriteLine(bpm * 10.35 + bmr * 12.40 + bvm * 8.15 + 0.2 * 
                (bpm * 10.35 + bmr * 12.40 + bvm * 8.15) + 2.50);
        }
    }
}
