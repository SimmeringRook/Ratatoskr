using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Creatures
{
    /// <summary>
    /// Anything that can be killed needs to implement these methods
    /// </summary>
    interface IKillable
    {
        bool IsAlive();

        void TakeDamage(int damage);

        void RecoverHealth(int amount);
    }
}
