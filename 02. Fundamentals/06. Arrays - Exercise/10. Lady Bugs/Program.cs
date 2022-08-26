using System;
using System.Linq;

namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldsize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldsize];
            int[] ladybugIndexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < fieldsize; i++)
            {
                if (ladybugIndexes.Contains(i))
                {
                    field[i] = 1;
                }




            }
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] com = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                int startindex = int.Parse(com[0]);
                string direction = com[1];
                int flylenght = int.Parse(com[2]);

                if (startindex < 0 || startindex >= field.Length)
                {
                    continue;
                }

                if (field[startindex] == 0)
                {
                    continue;
                }
                int nextindex = startindex;
                field[startindex] = 0;
                while (true)
                {
                    if (nextindex < 0 || nextindex >= field.Length)
                    {
                        break;
                    }



                    if (direction == "right")
                    {
                        nextindex += flylenght;

                    }
                    else if (direction == "left")
                    {
                        nextindex -= flylenght;

                    }
                    if (nextindex < 0 || nextindex >= field.Length)
                    {
                        break;
                    }
                    if (field[nextindex] == 0)
                    {
                        break;
                    }
                }
                if (nextindex >= 0 && nextindex < field.Length)
                {
                    field[nextindex] = 1;
                }




            }
            Console.WriteLine(String.Join(' ', field));
        }
    }
}