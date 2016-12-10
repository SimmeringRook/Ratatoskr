using Engine.Data;
using System;

namespace Engine.Core.Items.Weapons
{
    [SerializableAttribute]
    public class WeaponObj : ItemObj
    {
        public WeaponObj(WeaponData data) : base(data.ItemData)
        {
            EquipmentSlot = data.EquipmentSlotData.ID;
            string[] dice = data.DamageDice.Split('d');
            try
            {
                NumberOfDice = int.Parse(dice[0]);
                DamageDie = new Core.Dice(int.Parse(dice[1]));
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("!! Error :: Attempted to Build Weapon [{0}] into dice.", data.DamageDice));
                Console.WriteLine(string.Format("Message: {0} \nTrace:\n{1}", e.Message, e.StackTrace));
            }
            
        }
        public Dice DamageDie { get; private set; }
        public int NumberOfDice { get; private set; }
        public int EquipmentSlot { get; private set; }

        public static WeaponObj GetWeaponByID(int id)
        {
            WeaponObj weapon = null;
            try
            {
                using (RatatoskrContext context = new Data.RatatoskrContext())
                {
                    foreach (WeaponData data in context.WeaponDatas)
                    {
                        if (data.ItemID == id)
                            weapon = new WeaponObj(data);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("!! Error :: Attempted to Get WeaponObj by ID ({0})", id));
                Console.WriteLine(string.Format("Message: {0} \nTrace:\n{1}", e.Message, e.StackTrace));
            }
            return weapon;
        }
    }
}
