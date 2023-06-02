#nullable disable
namespace _09._Sum_Evens_in_Background
{
	internal class Program
	{
		static void Main(string[] args)
		{
			long sum = 0;
			Task task = Task.Run(() =>
			{
				for (int i = 1; i <= 1000000000; i++)
				{
					if (i % 2 == 0)
					{
						sum += i;
					}
				}
			});

			while (true)
			{
				string command = Console.ReadLine();
				if (command == "show")
				{
					Console.WriteLine(sum);
				}
				else if (command == "exit")
				{
					return;
				}
			}
		}
	}
}