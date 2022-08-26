using System;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            double maxnum = int.MinValue;
            while (num != "Stop")
            {
                int currentnum = int.Parse(num);
      
                if (currentnum > maxnum)
                {
                    maxnum = currentnum;
                }
                num = Console.ReadLine();
            }
            Console.WriteLine(maxnum);
        }
    }
}
