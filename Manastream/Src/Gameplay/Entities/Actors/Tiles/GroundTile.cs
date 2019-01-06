namespace Manastream.Src.Gameplay.Entities.Actors.Tiles
{
    #region Usings

    using Enums;

    #endregion

    /// <summary>
    /// The ground tile class.
    /// </summary>
    public class GroundTile : Tile
    {
        private static readonly int movementCost = 1;

        /// <summary>
        /// Initialises an instancec of the <see cref="GroundTile"/> class.
        /// </summary>
        public GroundTile(int boardX, int boardY, int canvasX, int canvasY)
            : base(boardX, boardY, canvasX, canvasY, movementCost, TileType.Ground, Textures.GroundTile)
        {
        }
    }
}
