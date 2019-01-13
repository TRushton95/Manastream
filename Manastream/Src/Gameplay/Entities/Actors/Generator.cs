namespace Manastream.Src.Gameplay.Entities.Actors
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actor;
    using Manastream.Src.Gameplay.Graphics;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The generator class.
    /// </summary>
    public class Generator : GameActor
    {
        #region Constants

        public const int Diameter = 75;

        #endregion

        #region Fields

        private bool active;
        private enum AnimationTypes
        {
            Default,
            Active
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Generator"/> class.
        /// </summary>
        public Generator()
            : base(0, 0, 0, 0)
        {
            active = false;

            this.Animations = new Dictionary<int, Animation>()
            {
                { (int)AnimationTypes.Default, Animation.SingleFrameAnimation(75, 75, Textures.Generator) },
                { (int)AnimationTypes.Active, new Animation(75, 75, 100, 4, Textures.ActiveGenerator) }
            };
        }

        #endregion

        #region Properties

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                if (value == true)
                {
                    AnimationIndex = (int)AnimationTypes.Active;
                }
                else
                {
                    AnimationIndex = (int)AnimationTypes.Default;
                }

                active = value;
            }
        }

        #endregion
    }
}
