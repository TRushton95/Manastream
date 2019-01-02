namespace Manastream.Src.Gameplay.Entities
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Microsoft.Xna.Framework;
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

        #region Methods

        /// <summary>
        /// Renders the board.
        /// </summary>
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

        #endregion

        #region Tile Utility

        /// <summary>
        /// Gets the tile at the given canvas position.
        /// </summary>
        public Tile GetTileAtCanvasPosition(int canvasX, int canvasY)
        {
            Tile result = null;

            //Get row and column canvas position is in
            int rowHeight = (Tile.Diameter / 4) * 3;

            int row = canvasX / rowHeight;
            
            int adjustedCanvasX = IsOdd(row) ? canvasX - (Tile.Diameter / 2) : canvasX;
            int column = adjustedCanvasX / Tile.Diameter;
            
            if (adjustedCanvasX < 0 || canvasY < 0) //Hack to avoid error as a result of diving a negative still resulting in column 0
            {
                return null;
            }

            //Calculate relative canvas position within the hex
            double relX;
            double relY = canvasY - (row * rowHeight);

            if (IsOdd(row))
            {
                relX = (canvasX - (column * Tile.Diameter)) - (Tile.Diameter / 2);
            }
            else
            {
                relX = canvasX - (column * Tile.Diameter);
            }

            //use y = mx + c to determine which side of the line the canvas position falls on
            double c = Tile.Diameter / 4;
            double m = c / (Tile.Diameter / 2);

            if (relY < (-m * relX) + c)
            {
                row--;

                if (!IsOdd(row))
                {
                    column--;
                }
            }
            else if (relY < (m * relX) - c)
            {
                row--;

                if (IsOdd(row))
                {
                    column++;
                }
            }

            result = GetTile(column, row);

            return result;
        }

        /// <summary>
        /// Gets the tile at a given coordinate, null if coordinate is out of range.
        /// </summary>
        private Tile GetTile(int x, int y)
        {
            Tile result = null;

            if (x >= 0 && x < width &&
                y >= 0 && y < height)
            {
                result = tiles[y][x];
            }

            return result;
        }

        #endregion

        #region Generation

        /// <summary>
        /// Generates the default board.
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

        #region Helper Methods

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
