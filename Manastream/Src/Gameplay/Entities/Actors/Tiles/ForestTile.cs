namespace Manastream.Src.Gameplay.Entities.Actors.Tiles
{
    #region Usings

    using Manastream.Src.Gameplay.Enums;

    #endregion

    /// <summary>
    /// The forest tile class.
    /// </summary>
    public class ForestTile : Tile
    {
        /// <summary>
        /// Initialises an instancec of the <see cref="ForestTile"/> class.
        /// </summary>
        public ForestTile(int boardX, int boardY, int canvasX, int canvasY)
            : base(boardX, boardY, canvasX, canvasY, TileType.Forest, 2, true, Textures.ForestTile)
        {
        }
    }
}
