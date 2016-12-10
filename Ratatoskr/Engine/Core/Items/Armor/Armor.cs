using System;

namespace Engine.Core.Items.Armor
{
    [SerializableAttribute]
    public class Armor : Item
    {
        public int ArmorRating { get; private set; }
    }
}
