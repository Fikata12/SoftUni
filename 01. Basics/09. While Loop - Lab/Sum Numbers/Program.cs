using System;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int input = 0;
            while (num > input)
            {
                input += int.Parse(Console.ReadLine());
            }
            Console.WriteLine(input);
        }
    }
}
    
