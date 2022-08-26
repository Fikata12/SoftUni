using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstNumber = 0;
            int secondNumber = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (firstNumber == secondNumber && input == ")")
                {
                    secondNumber--;
                }
                if (input == "(")
                {
                    firstNumber++;
                }
                if (input == ")")
                {
                    secondNumber++;
                }
            }
            if (firstNumber == secondNumber)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
