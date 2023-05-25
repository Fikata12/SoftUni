﻿#nullable disable
namespace _08._Sum_Evens_in_Range
{
	internal class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "show")
				{
					long result = SumEvensInRange();
					Console.WriteLine(result);
				}
			}
		}
		static long SumEvensInRange()
		{
			long sum = 0;
			for (int i = 1; i <= 1000; i++)
			{
				if (i % 2 == 0)
				{
					sum += i;
				}
			}
			return sum;
		}
	}
}