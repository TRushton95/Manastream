namespace Manastream.Src.Gameplay.Entities.Actors.Tiles
{
    #region Usings

    using Manastream.Src.Gameplay.Enums;

    #endregion

    /// <summary>
    /// The water tile class.
    /// </summary>
    public class WaterTile : Tile
    {
        /// <summary>
        /// Initialises an instancec of the <see cref="WaterTile"/> class.
        /// </summary>
        public WaterTile(int boardX, int boardY, int canvasX, int canvasY)
            : base(boardX, boardY, canvasX, canvasY, TileType.Water, 0, false, Textures.WaterTile)
        {
        }
    }
}
