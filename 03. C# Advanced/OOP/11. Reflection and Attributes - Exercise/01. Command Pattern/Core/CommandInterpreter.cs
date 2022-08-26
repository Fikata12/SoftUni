using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string commandName = args.Split()[0];
            Assembly assembly = Assembly.GetCallingAssembly();
            Type typeToInstance = assembly.GetTypes().FirstOrDefault(c => c.Name == $"{commandName}Command" && c.GetInterfaces().Any(i => i == typeof(ICommand)));
            if (typeToInstance != null)
            {
                ICommand command = Activator.CreateInstance(typeToInstance) as ICommand;
                return command.Execute(args.Split().Skip(1).ToArray());
            }
            else
            {
                return null;
            }
        }
    }
}
