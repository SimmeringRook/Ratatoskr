using Engine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Items.Weapons
{
    public class Weapon : Item
    {
        public Dice DamageDie { get; private set; }
        public int NumberOfDice { get; private set; }
    }
}
