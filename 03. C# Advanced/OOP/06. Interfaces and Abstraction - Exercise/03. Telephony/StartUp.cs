using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbersToCall = Console.ReadLine().Split().ToArray();
            string[] sitesToBrowse = Console.ReadLine().Split().ToArray();
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            foreach (var number in numbersToCall)
            {
                if (number.Length == 10)
                {
                    Console.WriteLine(smartphone.Calling(number));
                }
                else
                {
                    Console.WriteLine(stationaryPhone.Calling(number));
                }
            }
            foreach (var site in sitesToBrowse)
            {
                Console.WriteLine(smartphone.Browsing(site)); 
            }
        }
    }
}
