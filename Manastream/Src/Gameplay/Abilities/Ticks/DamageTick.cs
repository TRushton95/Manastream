namespace Manastream.Src.Gameplay.Abilities.Ticks
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities.Effects;
    using Manastream.Src.Gameplay.Entities.Actors;

    #endregion

    /// <summary>
    /// The damage tick class that applies damage on tick.
    /// </summary>
    public class DamageTick : BaseTick
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="DamageTick"/> class.
        /// </summary>
        public DamageTick(int value, int duration)
            : base(duration)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        public int Value
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Applies a tick of damage.
        /// </summary>
        protected override void ActivateDetail(Unit target)
        {
            AtomicEffects.Damage(target, Value);
        }

        #endregion
    }
}
