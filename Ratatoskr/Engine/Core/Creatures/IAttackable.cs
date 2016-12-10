namespace Engine.Core.Creatures
{
    /// <summary>
    /// These are methods that anything that can be attacked (which would be any creature)
    /// need to implement
    /// </summary>
    interface IAttackable
    {
        int GetArmorRating();
        int RollDamage();
        void Attack(CreatureObj target);
    }
}
