using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dates = Console.ReadLine();
            MatchCollection matchedDates = Regex.Matches(dates, @"\b(?<day>\d{2})(?<separator>[-|\/|.])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b");
            foreach (Match date in matchedDates)
            {
                Console.WriteLine($"Day: {date.Groups["day"].Value}, Month: {date.Groups["month"].Value}, Year: {date.Groups["year"].Value}");
            }
        }
    }
}
