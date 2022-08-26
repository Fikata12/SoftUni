using System;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            double minnum = int.MaxValue;
            while (num != "Stop")
            {
                int currentnum = int.Parse(num);
      
                if (currentnum < minnum)
                {
                    minnum = currentnum;
                }
                num = Console.ReadLine();
            }
            Console.WriteLine(minnum);
        }
    }
}
