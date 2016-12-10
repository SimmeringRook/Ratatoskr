using System;

namespace Engine.Core.Creatures
{
    [SerializableAttribute]
    class PlayerCreature : CreatureObj
    {
        public PlayerCreature(string name, int maxHealth, int hitDiceRNGSeed) : base(name, maxHealth, hitDiceRNGSeed)
        {

        }

    }
}
