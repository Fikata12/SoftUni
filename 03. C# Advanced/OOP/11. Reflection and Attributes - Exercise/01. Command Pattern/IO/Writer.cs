using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.IO.Contracts;

namespace CommandPattern.IO
{
    public class Writer : IWriter
    {
        public void Write(string args)
        {
            Console.Write(args);
        }

        public void WriteLine(string args)
        {
            Console.WriteLine(args);
        }
    }
}
