using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public sealed class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;
        public IReadOnlyCollection<Repair> Repairs
        {
            get { return repairs.AsReadOnly(); }
        }
        public Engineer(string id, string firstName, string lastName, string corps, decimal salary, List<Repair> repairs) : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }
        public override string ToString()
        {
            if (Repairs.Count > 0)
            {
                return base.ToString() + Environment.NewLine + "Repairs:" + Environment.NewLine + "  " + String.Join(Environment.NewLine + "  ", Repairs);
            }
            else
            {
                return base.ToString() + Environment.NewLine + "Repairs:";
            }
        }
    }
}
