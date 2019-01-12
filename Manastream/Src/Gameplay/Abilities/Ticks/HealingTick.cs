namespace Manastream.Src.Gameplay.Abilities.Ticks
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities.Effects;
    using Manastream.Src.Gameplay.Entities.Actors;

    #endregion

    /// <summary>
    /// The healing tick class that applies healing on tick.
    /// </summary>
    public class HealingTick : BaseTick
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="HealingTick"/> class.
        /// </summary>
        public HealingTick(int value, int duration)
            : base(duration)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        public int Value
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Applies a tick of healing.
        /// </summary>
        protected override void ActivateDetail(Unit target)
        {
            AtomicEffects.Heal(target, Value);
        }

        #endregion
    }
}
