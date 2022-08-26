using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string index = "no";
            for (int num = 0; num <= array.Length - 1; num++)
            {
                int leftSum = 0;
                for (int left = 0; left < num; left++)
                {
                    leftSum += array[left];                 
                }
                int rightSum = 0;
                for (int right = num + 1; right < array.Length; right++)
                {
                    rightSum += array[right];
                }
                if (leftSum == rightSum)
                {
                    index = Convert.ToString(num);
                }
            }
            Console.WriteLine(index);
        }
    }
}
