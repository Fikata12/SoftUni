using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public string Corps
        {
            get { return corps; }
            private set { corps = value; }

        }
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {Corps}";
        }
    }
}
