using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Creatures
{
    class PlayerCreature : Creature
    {
        public PlayerCreature(string name, int maxHealth, int hitDiceRNGSeed) : base(name, maxHealth, hitDiceRNGSeed)
        {

        }

    }
}
