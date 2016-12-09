namespace Engine.Core.Creatures
{
    /// <summary>
    /// Anything that can be killed needs to implement these methods
    /// </summary>
    interface IKillable
    {
        bool IsAlive();

        void TakeDamage(int damage);

        void RecoverHealth(int amount);
    }
}
