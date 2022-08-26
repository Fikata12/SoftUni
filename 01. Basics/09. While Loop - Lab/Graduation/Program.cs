using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int gradeCounter = 1;
            double average = 0;
            int badGradeCounter = 0;
            while (gradeCounter < 13)
            {
                double ocenka = double.Parse(Console.ReadLine());
                if (ocenka < 4)
                {
                    badGradeCounter++;
                    if (badGradeCounter > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {gradeCounter - 1} grade");
                        break;
                    }
                    average += ocenka;
                }
                else
                {
                    average += ocenka;
                }
                gradeCounter++;
            }
            if (badGradeCounter < 2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {average / 12:f2}");
            }
        }
    }
}