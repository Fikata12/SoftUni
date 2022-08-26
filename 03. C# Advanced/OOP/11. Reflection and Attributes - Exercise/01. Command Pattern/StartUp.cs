using CommandPattern.Core;
using CommandPattern.Core.Contracts;
using CommandPattern.IO;
using CommandPattern.IO.Contracts;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IEngine engine = new Engine(command, reader, writer);
            engine.Run();
        }
    }
}
