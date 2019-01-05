namespace Manastream.Src.Gameplay.Entities.Actors
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actor;
    using Manastream.Src.Gameplay.Graphics;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The unit class.
    /// </summary>
    public class Unit : GameActor
    {
        #region Constants

        public const int Diameter = 50;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Unit"/> class.
        /// </summary>
        public Unit(Animation animation)
            : base(0, 0, 0, 0, animation)
        {
        }

        #endregion
    }
}
