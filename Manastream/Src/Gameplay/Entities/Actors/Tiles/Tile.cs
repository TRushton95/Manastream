namespace Manastream.Src.Gameplay.Entities.Actors.Tiles
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actor;
    using Manastream.Src.Gameplay.Enums;

    #endregion

    /// <summary>
    /// The tile base class to represent a board tile.
    /// </summary>
    public abstract class Tile : GameActor
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Tile"/> class.
        /// </summary>
        public Tile()
        {
            TileType = TileType.Empty;
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
