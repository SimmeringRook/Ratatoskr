using System;

namespace Engine.Core.Items.Armor
{
    [SerializableAttribute]
    public class ArmorObj : ItemObj
    {
        public int ArmorRating { get; private set; }
    }
}
