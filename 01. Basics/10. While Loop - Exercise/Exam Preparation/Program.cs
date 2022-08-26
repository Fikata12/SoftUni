using System;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGrades = int.Parse(Console.ReadLine());
            string name = "";
            double grade = 0;
            int badGradesCounter = 0;
            double average = 0;
            int numberOfProblems = 0;
            bool isPrepared = false;
            string lastName = "";
            while (badGradesCounter < badGrades)
            {
                name = Console.ReadLine();
                if (name == "Enough")
                {
                    isPrepared = true;
                    break;
                }
                grade = double.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    badGradesCounter++;
                }
                numberOfProblems++;
                average += grade;
                lastName = name;
            }
            if (isPrepared)
            {
                Console.WriteLine($"Average score: {average / numberOfProblems:f2}");
                Console.WriteLine($"Number of problems: {numberOfProblems}");
                Console.WriteLine($"Last problem: {lastName}");
            }
            else
            {
                Console.WriteLine($"You need a break, {badGrades} poor grades.");
            }
        }
    }
}
