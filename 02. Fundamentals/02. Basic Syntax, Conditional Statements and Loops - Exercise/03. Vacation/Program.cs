using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string day = Console.ReadLine();
            double priceForASinglePerson = 0;
            if (day == "Friday")
            {
                if (typeOfGroup == "Students")
                {
                    priceForASinglePerson = 8.45;
                }
                else if (typeOfGroup == "Business")
                {
                    priceForASinglePerson = 10.90;
                }
                else if (typeOfGroup == "Regular")
                {
                    priceForASinglePerson = 15;
                }
            }
            else if (day == "Saturday")
            {
                if (typeOfGroup == "Students")
                {
                    priceForASinglePerson = 9.80;
                }
                else if (typeOfGroup == "Business")
                {
                    priceForASinglePerson = 15.60;
                }
                else if (typeOfGroup == "Regular")
                {
                    priceForASinglePerson = 20;
                }
            }
            else if (day == "Sunday")
            {
                if (typeOfGroup == "Students")
                {
                    priceForASinglePerson = 10.46;
                }
                else if (typeOfGroup == "Business")
                {
                    priceForASinglePerson = 16;
                }
                else if (typeOfGroup == "Regular")
                {
                    priceForASinglePerson = 22.50;
                }
            }
            double discount = 0;
            if (typeOfGroup == "Students" && countOfPeople > 29)
            {
                discount = 0.15 * countOfPeople * priceForASinglePerson;
            }
            else if (typeOfGroup == "Business" && countOfPeople > 99)
            {
                discount = 10 * priceForASinglePerson;
            }
            else if (typeOfGroup == "Regular" && countOfPeople > 9 && countOfPeople < 21)
            {
                discount = 0.05 * countOfPeople * priceForASinglePerson;
            }
            double price = countOfPeople * priceForASinglePerson - discount;
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
