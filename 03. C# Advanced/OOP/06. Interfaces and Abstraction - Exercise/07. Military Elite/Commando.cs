using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public sealed class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;
        public IReadOnlyCollection<Mission> Missions
        {
            get { return missions.AsReadOnly(); }
        }
        public Commando(string id, string firstName, string lastName, string corps, decimal salary, List<Mission> missions) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = missions;
        }
        public override string ToString()
        {
            if (Missions.Count > 0)
            {
                return base.ToString() + Environment.NewLine + "Missions:" + Environment.NewLine + "  " + String.Join(Environment.NewLine + "  ", missions.FindAll(m => m.State != null));
            }
            else
            {
                return base.ToString() + Environment.NewLine + "Missions:";
            }
        }
    }
}
