using Engine.Data;
using System;

namespace Engine.Core.Items.Armor
{
    [SerializableAttribute]
    public class ArmorObj : ItemObj
    {
        public ArmorObj(ArmorData data) : base(data.ItemData)
        {
            ArmorRating = data.ArmorRating;
            EquipmentSlot = data.EquipmentSlotData.ID;
        }
        public int EquipmentSlot { get; private set; }
        public int ArmorRating { get; private set; }

        public static ArmorObj GetArmorByID(int id)
        {
            ArmorObj armor = null;
            try
            {
                using (RatatoskrContext context = new Data.RatatoskrContext())
                {
                    foreach (ArmorData data in context.ArmorDatas)
                    {
                        if (data.ItemID == id)
                            armor = new ArmorObj(data);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("!! Error :: Attempted to Get ArmorObj by ID ({0})", id));
                Console.WriteLine(string.Format("Message: {0} \nTrace:\n{1}", e.Message, e.StackTrace));
            }
            return armor;
        }
    }
}
