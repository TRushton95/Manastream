namespace Manastream.Src.Gameplay.Entities
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.GameResources;
    using Microsoft.Xna.Framework.Graphics;
    using System;
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
        private List<Unit> units;
        private Textures Textures = Resources.GetInstance().Textures;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises an instance of the <see cref="Board"/> class.
        /// </summary>
        public Board(int width = DefaultWidth, int height = DefaultHeight)
        {
            this.width = DefaultWidth;
            this.height = DefaultHeight;
            this.Tiles = new Tile[0, 0];
            this.units = new List<Unit>();
        }

        #endregion

        #region Properties

        public Tile[,] Tiles
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the board state.
        /// Accepts mouse point as input so mouse may have camera transformation applied first.
        /// </summary>
        public void Update()
        {

        }

        /// <summary>
        /// Renders the board.
        /// </summary>
        public void Draw(SpriteBatch gameSpriteBatch)
        {
            foreach (Tile tile in Tiles)
            {
                tile.Draw(gameSpriteBatch);
            }

            foreach (Unit unit in units)
            {
                unit.Draw(gameSpriteBatch);
            }
        }

        #endregion

        #region Map Controls

        /// <summary>
        /// Attempt to spawn a unit at the specified location on the board and add it to the collection.
        /// </summary>
        public bool TrySpawnUnit(Unit unit, int x, int y)
        {
            bool result = false;

            Tile tile = GetTile(x, y);

            if (tile != null && tile.Occupant == null)
            {
                tile.Occupant = unit;
                unit.BoardX = x;
                unit.BoardY = y;
                unit.CanvasX = tile.CanvasX + (Tile.Diameter / 2) - (Unit.Diameter / 2);
                unit.CanvasY = tile.CanvasY + (Tile.Diameter / 2) - (Unit.Diameter / 2);

                units.Add(unit);

                result = true;
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
            Tile[,] result = new Tile[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int canvasXOffset = IsOdd(y) ? Tile.Diameter / 2 : 0;

                    int canvasX = x * Tile.Diameter + canvasXOffset;
                    int canvasY = (int)(y * (Tile.Diameter * 0.75));

                    result[x,y] = new EmptyTile(x, y, canvasX, canvasY);
                }
            }

            Tiles = result;
        }

        #endregion

        #region Tile Utility
        
        /// <summary>
        /// Gets the tile at a given coordinate, null if coordinate is out of range.
        /// </summary>
        private Tile GetTile(int x, int y)
        {
            Tile result = null;

            if (x >= 0 && x < Tiles.GetLength(0) &&
                y >= 0 && y < Tiles.GetLength(1))
            {
                result = Tiles[x,y];
            }

            return result;
        }

        /// <summary>
        /// Gets the tile at the given canvas position.
        /// </summary>
        public Tile GetTileAtCanvasPosition(int canvasX, int canvasY)
        {
            Tile result = null;

            //Get row and column canvas position is in
            int rowHeight = (Tile.Diameter / 4) * 3;

            int row = canvasY / rowHeight;
            bool rowIsOdd = IsOdd(row); //row is mutable during these calculations
            
            int adjustedCanvasX = rowIsOdd ? canvasX - (Tile.Diameter / 2) : canvasX;
            int column = adjustedCanvasX / Tile.Diameter;
            
            if (adjustedCanvasX < 0 || canvasY < 0) //Hack to avoid error as a result of diving a negative still resulting in column 0
            {
                return null;
            }

            //Calculate relative canvas position within the hex
            double relY = canvasY - (row * rowHeight);
            double relX;

            if (rowIsOdd)
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

            if (relY < (-m * relX) + c) //left edge
            {
                row--;
                Console.WriteLine("Left edge: Row--");

                if (!rowIsOdd)
                {
                    column--;
                    Console.WriteLine("Left edge: Column--");
                }
            }
            else if (relY < (m * relX) - c) //right edge
            {
                row--;
                Console.WriteLine("Right edge: Row--");

                if (rowIsOdd)
                {
                    column++;
                    Console.WriteLine("Right edge: Column++");
                }
            }

            result = GetTile(column, row);

            return result;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Determines whether an integer is odd
        /// </summary>
        private bool IsOdd(int i)
        {
            return i % 2 == 1;
        }

        #endregion
    }
}
