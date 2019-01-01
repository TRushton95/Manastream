namespace Manastream.Src.Gameplay.Entities
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The board class that contains a set of <see cref="Tile"/> classes.
    /// </summary>
    public class Board
    {
        #region Constants

        private const int DefaultWidth = 15;
        private const int DefaultHeight = 10;

        #endregion

        #region Fields

        private int width, height;
        private List<List<Tile>> tiles;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises an instance of the <see cref="Board"/> class.
        /// </summary>
        public Board()
        {
            this.width = DefaultWidth;
            this.height = DefaultHeight;
            this.tiles = new List<List<Tile>>();
        }

        #endregion

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (List<Tile> row in tiles)
            {
                foreach (Tile tile in row)
                {
                    tile.Draw(spriteBatch);
                }
            }
        }

        #region Generation

        /// <summary>
        /// Generates a default board.
        /// </summary>
        public void Generate()
        {
            List<List<Tile>> result = new List<List<Tile>>();

            for (int y = 0; y < height; y++)
            {
                List<Tile> row = new List<Tile>();
                
                int canvasXOffset = IsOdd(y) ? Tile.Diameter / 2 : 0;

                for (int x = 0; x < width; x++)
                {
                    int canvasX = x * Tile.Diameter + canvasXOffset;
                    int canvasY = (int)(y * (Tile.Diameter * 0.75));

                    row.Add(new EmptyTile(x, y, canvasX, canvasY));
                }

                result.Add(row);
            }

            tiles = result;
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Determines whether an integer is odd
        /// </summary>
        private bool IsOdd(int i)
        {
            return i % 2 == 0;
        }

        #endregion
    }
}
