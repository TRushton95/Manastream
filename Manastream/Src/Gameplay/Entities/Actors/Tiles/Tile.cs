namespace Manastream.Src.Gameplay.Entities.Actors.Tiles
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actor;
    using Manastream.Src.Gameplay.Enums;
    using Manastream.Src.Gameplay.Graphics;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

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
        //DEBUG  - Currently only passing a texture and manually building non-moving animation.
        public Tile(int boardX, int boardY, int canvasX, int canvasY, TileType tileType, Texture2D texture)
            : base(boardX, boardY, canvasX, canvasY, new Animation(101, 101, 0, 1, texture))
        {
            this.TileType = tileType;
            this.Occupant = null;
        }

        #endregion

        #region Properties
            
        public TileType TileType
        {
            get;
        }

        public Unit Occupant
        {
            get;
            set;
        }

        #endregion
    }
}
