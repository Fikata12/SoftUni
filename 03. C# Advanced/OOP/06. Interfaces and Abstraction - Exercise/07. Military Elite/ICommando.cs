using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<Mission> Missions { get; }
    }
}
