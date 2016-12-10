using System;

namespace Engine.Core.Creatures
{
    [SerializableAttribute]
    class MonsterCreature : CreatureObj
    {
        public MonsterCreature(string name, int maxHealth, int hitDiceRNGSeed) : base(name, maxHealth, hitDiceRNGSeed)
        {

        }
    }
}
