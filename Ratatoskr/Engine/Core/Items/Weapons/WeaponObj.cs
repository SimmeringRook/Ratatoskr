using System;

namespace Engine.Core.Items.Weapons
{
    [SerializableAttribute]
    public class WeaponObj : ItemObj
    {
        public Dice DamageDie { get; private set; }
        public int NumberOfDice { get; private set; }
    }
}
