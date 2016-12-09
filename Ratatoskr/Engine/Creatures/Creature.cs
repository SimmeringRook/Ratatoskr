using Engine.Core;
using Engine.Items.Armor;
using Engine.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Creatures
{
    /// <summary>
    /// The base class of every creature;
    /// By default, every creature should be able to be Killed and be attacked
    /// </summary>
    public class Creature : IKillable, IAttackable
    {
        public Creature(string name, int maxHealth, int hitDiceSeed)
        {
            this.Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            HitDice = new Dice(20, hitDiceSeed);
        }

        #region Attributes
        public string Name { get; private set; }
        public int CurrentHealth { get; protected set; }
        public int MaxHealth { get; private set; }
        #endregion

        #region Equipped Items
        public Dice HitDice { get; private set; }

        // Damage
        public int BaseDamage { get; private set; }
        public Weapon EquippedWeapon { get; protected set; }

        //Armor
        public int BaseArmor { get; private set; }
        public List<Armor> EquippedArmor { get; protected set; }
        #endregion

        #region IKillable Methods
        /// <summary>
        /// Gets the alive/dead status of the specified Creature
        /// </summary>
        /// <returns></returns>
        public bool IsAlive()
        {
            if (CurrentHealth > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Heals the creature for an amount
        /// </summary>
        /// <param name="amount"></param>
        public void RecoverHealth(int amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
        }

        /// <summary>
        /// Deals damage to creature
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
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
            
            foreach (Armor gear in EquippedArmor)
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
            // If there is an equipped weapon, get the roll results of the dice
            if (EquippedWeapon != null)
            {
                int result = 0;
                for (int dice = 1; dice <= EquippedWeapon.NumberOfDice; dice++)
                    result += EquippedWeapon.DamageDie.GetRollResult();
                return result;
            }
            else
            {
                //Otherwise, we're punching with fists
                return BaseDamage;
            }
        }

        /// <summary>
        /// Handles a standard attack from a Creature vs another Creature
        /// </summary>
        /// <param name="target"></param>
        public void Attack(Creature target)
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
    }
}
