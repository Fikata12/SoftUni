using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int mainNumInTheSequence = 0;
            int longestSequence = int.MinValue;
            int sequenceCounter = 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] == array[i - 1])
                {
                    sequenceCounter++;
                    if (sequenceCounter >= longestSequence)
                    {
                        longestSequence = sequenceCounter;
                        mainNumInTheSequence = array[i];
                    }
                }
                else
                {
                    sequenceCounter = 1;
                }               
            }
            for (int i = 0; i < longestSequence; i++)
            {
                Console.Write(mainNumInTheSequence + " ");
            }
        }
    }
}
