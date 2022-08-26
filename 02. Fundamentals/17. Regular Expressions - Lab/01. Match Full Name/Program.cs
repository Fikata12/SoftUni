using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            MatchCollection matchedNames = Regex.Matches(names, @"\b[A-Z][a-z]+ [A-Z][a-z]+\b");
            Console.WriteLine(String.Join(' ', matchedNames));    
            
            //\w - [A - Z][a - z][0 - 9]_
            //\W - opposite \w
            //\s - " "
            //\S - opposite \s
            //\d - 0 - 9
            //\D - opposite 0 - 9

            //\+\d * -> + 359885976002 a + b-> + 35988597600 +
            //\+\d + -> + 359885976002 a + b-> + 359885976002
            //\+\d ? -> + 359885976002 a + b-> + 3 +

            //\+\d{ 4} -> +4 digits
            //\+\d{ 1,4} -> +between 1 and 4 digits
            //\+\d{ 4,} -> +above(including) 4 digits

            //d{ 2}-(?:\w{ 3})-\d{ 4} -> (?:) -> non capture group
        }
    }
}
