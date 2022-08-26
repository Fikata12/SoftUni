using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            MatchCollection matchedNumbers = Regex.Matches(numbers, @"\+359([-| ])2\1\d{3}\1\d{4}\b");
            Console.WriteLine(String.Join(", ", matchedNumbers));
        }
    }
}
