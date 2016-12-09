namespace Engine.Core.Items.Weapons
{
    public class Weapon : Item
    {
        public Dice DamageDie { get; private set; }
        public int NumberOfDice { get; private set; }
    }
}
