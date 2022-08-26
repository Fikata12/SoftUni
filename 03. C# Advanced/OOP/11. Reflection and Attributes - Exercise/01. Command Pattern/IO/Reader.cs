using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.IO.Contracts;


namespace CommandPattern.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
