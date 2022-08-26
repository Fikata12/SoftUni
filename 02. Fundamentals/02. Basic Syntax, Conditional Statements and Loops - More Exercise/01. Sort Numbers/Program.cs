using System;

namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = new double[3];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = double.Parse(Console.ReadLine());
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int s = i + 1; s < array.Length; s++)
                {
                    if (array[i] < array[s])
                    {
                        double t = array[i];
                        array[i] = array[s];
                        array[s] = t;
                    }
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            //OR

            //    int n1 = int.MinValue;
            //int n2 = int.MinValue;
            //int n3 = int.MinValue;

            //for (int i = 0; i < 3; i++)
            //{
            //    int numberToCheck = int.Parse(Console.ReadLine());
            //    if (numberToCheck > n1)
            //    {
            //        n3 = n2;
            //        n2 = n1;
            //        n1 = numberToCheck;
            //    }
            //    else if (numberToCheck > n2)
            //    {
            //        n3 = n2;
            //        n2 = numberToCheck;
            //    }
            //    else if (numberToCheck > n3)
            //    {
            //        n3 = numberToCheck;
            //    }

            //}
            //Console.WriteLine(n1);
            //Console.WriteLine(n2);
            //Console.WriteLine(n3);
        }
    }
}
