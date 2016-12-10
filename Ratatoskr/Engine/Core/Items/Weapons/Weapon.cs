using System;

namespace Engine.Core.Items.Weapons
{
    [SerializableAttribute]
    public class Weapon : Item
    {
        public Dice DamageDie { get; private set; }
        public int NumberOfDice { get; private set; }
    }
}
