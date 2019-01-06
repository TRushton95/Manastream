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
        private static int movementCost = 10;

        /// <summary>
        /// Initialises an instance of the <see cref="EmptyTile"/> class.
        /// </summary>
        public EmptyTile(int boardX, int boardY, int canvasX, int canvasY)
            : base(boardX, boardY, canvasX, canvasY, movementCost, TileType.Empty, Textures.EmptyTile)
        {
        }
    }
}
