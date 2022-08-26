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
            double result = 0.0;
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
                    if (result - Convert.ToInt32(result) == 0)
                    {
                        result = Convert.ToInt32(result);
                    }
                    break;
                case '%':
                    result = N1 % N2;
                    break;
            }
            if (result % 2 == 0 && opr != '/' && opr != '%')
            {
                type = "even";
            }
            else if (result % 2 != 0 && opr != '/' && opr != '%')
            {
                type = "odd";
            }
            if (N2 != 0 && opr != '%' && opr != '/')
            {
                Console.WriteLine($"{N1} {opr} {N2} = {result} - {type}");
            }
            else if (N2 != 0 && opr == '%' || N2 != 0 && opr == '/')
            {
                Console.WriteLine($"{N1} {opr} {N2} = {result}");
            }
            else if (N2 == 0)
            {
                Console.WriteLine($"Cannot divide {N1} by zero");
            }
        }
    }
}