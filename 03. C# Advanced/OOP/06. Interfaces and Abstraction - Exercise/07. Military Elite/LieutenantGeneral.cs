using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public sealed class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;
        public IReadOnlyCollection<Private> Privates
        {
            get { return privates.AsReadOnly(); }
        }
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, List<Private> privates) : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }
        public override string ToString()
        {
            if (Privates.Count > 0)
            {
                return base.ToString() + Environment.NewLine + "Privates:" + Environment.NewLine + "  " + String.Join(Environment.NewLine + "  ", Privates);
            }
            else
            {
                return base.ToString() + Environment.NewLine + "Privates:";
            }
        }
    }
}
