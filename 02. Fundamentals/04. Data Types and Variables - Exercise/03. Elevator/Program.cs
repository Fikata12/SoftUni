using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            double nOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double courses = Math.Ceiling(nOfPeople / capacity);
            Console.WriteLine(courses);
        }
    }
}
