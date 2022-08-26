using System;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double time1m = double.Parse(Console.ReadLine());
            double sd = Math.Floor(distance / 15) * 12.5;
            double time = time1m * distance + sd;
            if (time < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:F2} seconds.");
            }
            else if(time >= record)
            {
                Console.WriteLine($"No, he failed! He was {time - record:F2} seconds slower.");
            }
        }
    }
}
    