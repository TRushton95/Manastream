namespace Manastream.Src.Gameplay.Entities.Actors.Tiles
{
    #region Usings

    using Enums;

    #endregion

    /// <summary>
    /// The empty tile class.
    /// </summary>
    public class EmptyTile : Tile
    {
        /// <summary>
        /// Initialises an instance of the <see cref="EmptyTile"/> class.
        /// </summary>
        public EmptyTile(int boardX, int boardY, int canvasX, int canvasY)
            : base(boardX, boardY, canvasX, canvasY, TileType.Empty, Textures.EmptyTile)
        {
        }
    }
}
