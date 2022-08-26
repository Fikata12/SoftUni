using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            private set { salary = value; }
        }
        public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }
        public override string ToString()
        {
            return base.ToString() + $"Salary: {Salary:f2}";
        }
    }
}
