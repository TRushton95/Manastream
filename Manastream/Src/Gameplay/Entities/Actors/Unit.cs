namespace Manastream.Src.Gameplay.Entities.Actors
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actor;
    using Microsoft.Xna.Framework.Graphics;

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
        public Unit(int boardX, int boardY, int canvasX, int canvasY, Texture2D texture)
            : base(boardX, boardY, canvasX, canvasY, texture)
        {
        }

        #endregion
    }
}
