using System;

namespace Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            char opr = char.Parse(Console.ReadLine());
            double result = 0;
            string type = "0";

            switch (opr)
            {
                case '+':
                    result = N1 + N2;
                    break;
                case '-':
                    result = N1 - N2;
                    break;
                case '*':
                    result = N1 * N2;
                    break;
                case '/':
                    result = Convert.ToDouble(N1) / N2;
                    break;
                case '%':
                    if (N2 == 0)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = N1 % N2;
                    }
                    break;
            }
            if (opr != '%' && opr != '/' )
            {
                if (result % 2 == 0)
                {
                    type = "even";
                }
                else
                {
                    type = "odd";
                }
            }

            if (N2 != 0)
            {
                if (opr == '-' || opr == '+' || opr == '*')
                {
                    Console.WriteLine($"{N1} {opr} {N2} = {result} - {type}");
                }
                else if (opr == '/')
                {
                    Console.WriteLine($"{N1} / {N2} = {result:f2}");
                }
                else
                {
                    Console.WriteLine($"{N1} % {N2} = {Math.Abs(result)}");
                }
            }
            else
            {
                Console.WriteLine($"Cannot divide {N1} by zero");
            }
        }
    }
}
