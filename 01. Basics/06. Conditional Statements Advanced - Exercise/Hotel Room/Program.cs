using System;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int noshtuvki = int.Parse(Console.ReadLine());
            double namaleniest = 0;
            double namalenieap = 0;
            double cenast = 0;
            double cenaap = 0;
            switch (month)
            {
                case "May":
                case "October":
                    cenast = 50;
                    cenaap = 65;
                    if (noshtuvki > 7)
                    {
                        namaleniest = 0.05;
                    }
                     if (noshtuvki > 14)
                    {
                        namaleniest = 0.3;
                        namalenieap = 0.1;
                    }
                    break;
                case "June":
                case "September":
                    cenast = 75.2;
                    cenaap = 68.7;
                    if (noshtuvki > 14)
                    {
                        namaleniest = 0.2;
                        namalenieap = 0.1;
                    }
                    break;
                case "July":
                case "August":
                    cenast = 76;
                    cenaap = 77;
                    if (noshtuvki > 14)
                    {
                        namalenieap = 0.1;
                    }
                    break;
            }

            Console.WriteLine($"Apartment: {cenaap * noshtuvki - namalenieap * (cenaap * noshtuvki):f2} lv.");
            Console.WriteLine($"Studio: {cenast * noshtuvki - namaleniest * (cenast * noshtuvki):f2} lv.");

        }
    }
}
