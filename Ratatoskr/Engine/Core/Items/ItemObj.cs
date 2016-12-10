using Engine.Data;
using System;

namespace Engine.Core.Items
{
    [SerializableAttribute]
    public class ItemObj : ItemData
    {
        public ItemObj(ItemData data)
        {
            this.ID = data.ID;
            this.Name = data.Name;
            this.Type = data.Type;
        }
    }
}
