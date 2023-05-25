using _10._Chronometer.Models;

namespace _10._Chronometer
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			string command = Console.ReadLine();
			Chronometer chronometer = new Chronometer();
			while (command != "exit")
			{
				if(command == "start")
				{
					chronometer.Start();
				}
				else if (command == "stop")
				{
					chronometer.Stop();
				}
				else if (command == "lap")
				{
                    Console.WriteLine(chronometer.Lap());
                }
				else if (command == "laps")
				{
					if (chronometer.Laps.Count == 0)
					{
                        Console.WriteLine("No Laps!");
						continue;
                    }
                    Console.WriteLine("Laps:");
					for (int i = 0; i < chronometer.Laps.Count; i++)
					{
                        Console.WriteLine($"{i + 1:d2}. {chronometer.Laps[i]}");
                    }
                }
				else if (command == "reset")
				{
					chronometer.Reset();
				}
				else if (command == "time")
				{
                    Console.WriteLine(chronometer.GetTime);
                }
				command = Console.ReadLine();
			}
			chronometer.Stop();
        }
	}
}