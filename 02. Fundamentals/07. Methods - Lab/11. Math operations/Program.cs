using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculate(n1, @operator, n2));

        }
        static double Calculate(int n1, char @operator, int n2)
        {
            double result = 0;
            switch (@operator)
            {
                case '/':
                    result = n1 / n2;
                    break;
                case '*':
                    result = n1 * n2;
                    break;
                case '+':
                    result = n1 + n2;
                    break;
                case '-':
                    result = n1 - n2;
                    break;
            }
            return result;
        }
    }
}
