using System;
using System.Text;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(RepeatString(text, n));
        }
        static string RepeatString(string text, int n)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                stringBuilder.Append(text);
            }
            return stringBuilder.ToString();
        }
    }
}
