using System;

namespace Engine.Core.Creatures
{
    [SerializableAttribute]
    class PlayerCreature : Creature
    {
        public PlayerCreature(string name, int maxHealth, int hitDiceRNGSeed) : base(name, maxHealth, hitDiceRNGSeed)
        {

        }

    }
}
