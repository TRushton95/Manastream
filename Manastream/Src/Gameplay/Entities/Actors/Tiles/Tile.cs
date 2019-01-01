namespace Manastream.Src.Gameplay.Entities.Actors.Tiles
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actor;
    using Manastream.Src.Gameplay.Enums;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The tile base class to represent a board tile.
    /// </summary>
    public abstract class Tile : GameActor
    {
        #region Constants

        public static readonly int Diameter = 100;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Tile"/> class.
        /// </summary>
        public Tile(int boardX, int boardY, int canvasX, int canvasY, TileType tileType, Texture2D texture)
            : base(boardX, boardY, canvasX, canvasY, texture)
        {
            this.TileType = tileType;
        }

        #endregion

        #region Properties
            
        public TileType TileType
        {
            get;
        }

        #endregion
    }
}
