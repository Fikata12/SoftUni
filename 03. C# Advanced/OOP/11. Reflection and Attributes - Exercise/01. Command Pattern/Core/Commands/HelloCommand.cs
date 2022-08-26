using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    public class HelloCommand : ICommand
    {
        IEnumerable objects = new List<object>();
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
