using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public interface IAttacker
    {
        public string Name { get; }

        public int Experience { get; }

        public IWeapon Weapon { get; }

        public void Attack(ITarget target);
    }
}
