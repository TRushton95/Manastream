namespace Manastream.Src.Gameplay.Abilities.Ticks
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;

    #endregion

    /// <summary>
    /// The base tick class that defines the basic structure of an effect tick.
    /// </summary>
    public abstract class BaseTick
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="BaseTick"/> class.
        /// </summary>
        public BaseTick(int duration)
        {
            this.Duration = duration;
            this.RemainingDuration = duration;
        }

        #endregion

        #region Properties

        public int Duration
        {
            get;
        }

        public int RemainingDuration
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Apply a single tick.
        /// </summary>
        public void Activate(Unit target)
        {
            ActivateDetail(target);
            RemainingDuration--;
        }

        /// <summary>
        /// Defines the implementation details of a tick.
        /// </summary>
        protected abstract void ActivateDetail(Unit target);

        #endregion
    }
}
