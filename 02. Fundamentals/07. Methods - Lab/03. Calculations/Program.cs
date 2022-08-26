using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            if (operation == "add")
            {
                Add(n1, n2);
            }
            else if (operation == "multiply")
            {
                Multiply(n1, n2);
            }
            else if (operation == "subtract")
            {
                Subtract(n1, n2);
            }
            else if (operation == "divide")
            {
                Divide(n1, n2);
            }
        }
        static void Add(int n1, int n2)
        {
            Console.WriteLine(n1 + n2);
        }
        static void Multiply(int n1, int n2)
        {
            Console.WriteLine(n1 * n2);
        }
        static void Subtract(int n1, int n2)
        {
            Console.WriteLine(n1 - n2);
        }
        static void Divide(int n1, int n2)
        {
            Console.WriteLine(n1 / n2);
        }
    }
}
