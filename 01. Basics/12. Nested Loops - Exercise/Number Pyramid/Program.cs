using System;

namespace Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentnum = 1;
            bool isBigger = false;
            for (int row = 1; row <= n; row++)
            {
                for (int nums = 1; nums <= row; nums++)
                {
                    if (currentnum > n)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write(currentnum + " ");
                    currentnum++;
                }
                if (isBigger)
                {
                    break;
                }
                Console.WriteLine(); 
            } 
        }
    }
}


