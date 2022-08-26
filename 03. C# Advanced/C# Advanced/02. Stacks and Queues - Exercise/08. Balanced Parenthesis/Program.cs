using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seqOfParenth = Console.ReadLine();
            Stack<char> stackOfParenth = new Stack<char>();
            bool areBalanced = false;
            foreach (char bracket in seqOfParenth)
            {
                if (bracket == '{' || bracket == '[' || bracket == '(')
                {
                    stackOfParenth.Push(bracket);
                }
                else
                {
                    if (stackOfParenth.Count > 0)
                    {
                        if (bracket == '}' && stackOfParenth.Pop() == '{')
                        {
                            areBalanced = true;
                        }
                        else if (bracket == ']' && stackOfParenth.Pop() == '[')
                        {
                            areBalanced = true;
                        }
                        else if (bracket == ')' && stackOfParenth.Pop() == '(')
                        {
                            areBalanced = true;
                        }                   
                    }
                    else
                    {
                        areBalanced = false;
                        break;
                    }
                }
            }
            if (areBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
