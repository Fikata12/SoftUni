using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.IO.Contracts
{
    public interface IWriter
    {
        public void Write(string args);
        public void WriteLine(string args);
    }
}
