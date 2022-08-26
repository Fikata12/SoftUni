using System;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int length = stack.Peek() + 1;
                    Console.WriteLine(expression.Substring(stack.Pop(), i - length));
                }
            }
        }
    }
}
