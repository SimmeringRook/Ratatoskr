using Engine.Core.Items.Armor;
using Engine.Core.Items.Weapons;
using Engine.Data;
using System;
using System.Collections.Generic;

namespace Engine.Core.Creatures
{
    /// <summary>
    /// The base class of every creature;
    /// By default, every creature should be able to be Killed and be attacked
    /// </summary>
    [SerializableAttribute]
    public class CreatureObj : CreatureData, IKillable, IAttackable
    {
        #region Constructors
        public CreatureObj(string name, int maxHealth, int hitDiceSeed)
        {
            this.Name = name;
            this.MaxHitPoints = maxHealth;
            this.CurrentHitPoints = maxHealth;
            this.BaseArmor = 8;
            HitDice = new Dice(20, hitDiceSeed);
            

            EquippedArmor = new List<ArmorObj>();
        }

        public CreatureObj(CreatureData creature, int hitDiceSeed)
        {
            this.Name = creature.Name;
            this.CurrentHitPoints = creature.CurrentHitPoints;
            this.MaxHitPoints = creature.MaxHitPoints;
            this.BaseArmor = creature.BaseArmor;

            HitDice = new Dice(20, hitDiceSeed);

            AttemptEquipWeapon(creature.EquippedWeaponID);

            EquippedArmor = new List<ArmorObj>();
            AttemptEquipArmor(creature.Armor_ChestID);
            AttemptEquipArmor(creature.Armor_HeadID);
            AttemptEquipArmor(creature.Armor_LegsID);

        }

        #endregion

        #region Equipped Items
        public Dice HitDice { get; private set; }
        // Damage
        public WeaponObj EquippedWeapon { get; protected set; }
        //Armor
        public List<ArmorObj> EquippedArmor { get; protected set; }
        #endregion

        #region IKillable Methods
        /// <summary>
        /// Gets the alive/dead status of the specified Creature
        /// </summary>
        /// <returns></returns>
        public bool IsAlive()
        {
            if (CurrentHitPoints > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Heals the creature for an amount
        /// </summary>
        /// <param name="amount"></param>
        public void RecoverHealth(int amount)
        {
            CurrentHitPoints += amount;
            if (CurrentHitPoints > MaxHitPoints)
                CurrentHitPoints = MaxHitPoints;
        }

        /// <summary>
        /// Deals damage to creature
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            CurrentHitPoints -= damage;
        }
        #endregion

        #region IAttackable Methods
        /// <summary>
        /// Calculates the Armor Rating from all the equipped gear
        /// </summary>
        /// <returns></returns>
        public int GetArmorRating()
        {
            int armorRating = BaseArmor;
            
            foreach (ArmorObj gear in EquippedArmor)
            {
                if (gear != null) 
                    armorRating += gear.ArmorRating;
            }
            return armorRating;
        }

        /// <summary>
        /// Calculates the Damage dealt
        /// </summary>
        /// <returns>The Damage that will be dealt</returns>
        public int RollDamage()
        {
            int result = 0;
            for (int dice = 1; dice <= EquippedWeapon.NumberOfDice; dice++)
                result += EquippedWeapon.DamageDie.GetRollResult();
            return result;
        }

        /// <summary>
        /// Handles a standard attack from a Creature vs another Creature
        /// </summary>
        /// <param name="target"></param>
        public void Attack(CreatureObj target)
        {
         //TODO: Implement CombatResults   
            if (this.HitDice.GetRollResult() > target.GetArmorRating())
            {
                //this hit Target, deal damage
                int damageDealt = this.RollDamage();
                target.TakeDamage(damageDealt);
            }
        }
        #endregion

        private void AttemptEquipWeapon(int id)
        {
            WeaponObj weapon = WeaponObj.GetWeaponByID(id);
            if (weapon != null)
                this.EquippedWeapon = weapon;
            else
                this.EquippedWeapon = WeaponObj.GetWeaponByID(1); //1 == Fists
        }

        private void AttemptEquipArmor(int? id)
        {
            ArmorObj armor = null;
            if (id.HasValue)
                armor = ArmorObj.GetArmorByID(id.Value);

            if (armor != null)
            {
                if (EquippedArmor.Count > 0)
                {
                    ArmorObj pieceToReplace = null;
                    foreach (ArmorObj equipped in EquippedArmor)
                    {
                        if (equipped.EquipmentSlot == armor.EquipmentSlot)
                        {
                            pieceToReplace = equipped;
                            break;
                        }
                    }
                    EquippedArmor.Remove(pieceToReplace);
                }
                EquippedArmor.Add(armor);
            }
        }

        public CreatureData GetData(CreatureObj creature)
        {
            CreatureData data = new Data.CreatureData();
            data.Account = creature.Account;

            data.CurrentHitPoints = creature.CurrentHitPoints;
            data.MaxHitPoints = creature.MaxHitPoints;
            data.Name = creature.Name;

            data.BaseArmor = creature.BaseArmor;
            data.Armor_ChestID = creature.Armor_ChestID;
            data.Armor_HeadID = creature.Armor_HeadID;
            data.Armor_LegsID = creature.Armor_LegsID;
            data.EquippedWeaponID = creature.EquippedWeaponID;
            
            return data;
        }
    }
}
