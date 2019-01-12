namespace Manastream.Src.Gameplay.Abilities.Effects
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;

    #endregion

    /// <summary>
    /// The atomic effects class that is the single source of any effects that act on the board or units.
    /// </summary>
    public static class AtomicEffects
    {
        #region Methods

        /// <summary>
        /// Deals damage to the target unit.
        /// </summary>
        public static void Damage(Unit target, int value)
        {
            target.CurrentHealth -= value;

            if (target.CurrentHealth < 0)
            {
                target.CurrentHealth = 0;
            }
        }

        /// <summary>
        /// Heals the target unit.
        /// </summary>
        public static void Heal(Unit target, int value)
        {
            target.CurrentHealth += value;

            if (target.CurrentHealth > target.MaxHealth)
            {
                target.CurrentHealth = target.MaxHealth;
            }
        }

        #endregion
    }
}
