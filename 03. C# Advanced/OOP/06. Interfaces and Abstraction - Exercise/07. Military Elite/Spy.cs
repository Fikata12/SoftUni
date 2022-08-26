using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public sealed class Spy : Soldier, ISpy
    {
        private int codeNumber;
        public int CodeNumber
        {
            get { return codeNumber; }
            set { codeNumber = value; }
        }
        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Code Number: {CodeNumber}";
        }
    }
}
