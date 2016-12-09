using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Creatures
{
    /// <summary>
    /// These are methods that anything that can be attacked (which would be any creature)
    /// need to implement
    /// </summary>
    interface IAttackable
    {
        int GetArmorRating();
        int RollDamage();
        void Attack(Creature target);
    }
}
