namespace Manastream.Src.Gameplay.Entities.Actors
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actor;
    using Manastream.Src.Gameplay.Graphics;

    #endregion

    /// <summary>
    /// The generator class.
    /// </summary>
    public class Generator : GameActor
    {
        #region Constants

        public const int Diameter = 75;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Generator"/> class.
        /// </summary>
        public Generator()
            : base(0, 0, 0, 0, Animation.SingleFrameAnimation(75, 75, Textures.Generator))
        {
        }

        #endregion

        #region Properties

        public bool Active
        {
            get;
            set;
        }

        #endregion
    }
}
