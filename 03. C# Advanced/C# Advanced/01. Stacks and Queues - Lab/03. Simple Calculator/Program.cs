using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split().ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (i == 0)
                {
                    stack.Push(int.Parse(expression[i]));
                }
                else if (expression[i] == "+")
                {
                    stack.Push(int.Parse(expression[i + 1]));
                }
                else if ((expression[i] == "-"))
                {
                    stack.Push(-int.Parse(expression[i + 1]));
                }
            }
            Console.WriteLine(stack.Sum());
        }
    }
}
