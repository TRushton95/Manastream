namespace Manastream.Src.Gameplay.Entities
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.GameResources;
    using Manastream.Src.Utility;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
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
        private Tile[,] tiles;
        private Tile highlightedTile;
        private Camera camera;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises an instance of the <see cref="Board"/> class.
        /// </summary>
        public Board(int width = DefaultWidth, int height = DefaultHeight)
        {
            this.width = DefaultWidth;
            this.height = DefaultHeight;
            this.camera = new Camera(0, 0);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the board state.
        /// Accepts mouse point as input so mouse may have camera transformation applied first.
        /// </summary>
        public void Update()
        {
            //DEBUG
            camera.Update();
            Point adjustedMouse = Vector2.Transform(MouseInfo.Position.ToVector2(), Matrix.Invert(camera.GetTranslationMatrix())).ToPoint();
            highlightedTile = GetTileAtCanvasPosition(adjustedMouse.X, adjustedMouse.Y);
        }

        /// <summary>
        /// Renders the board.
        /// </summary>
        public void Draw(SpriteBatch gameSpriteBatch)
        {
            gameSpriteBatch.Begin(transformMatrix: camera.GetTranslationMatrix());

            foreach (Tile tile in tiles)
            {
                tile.Draw(gameSpriteBatch);
            }

            //DEBUG
            if (highlightedTile != null)
            {
                gameSpriteBatch.Draw(Resources.GetInstance().Textures.TileHighlight, new Vector2(highlightedTile.CanvasX, highlightedTile.CanvasY), Color.White);
            }

            gameSpriteBatch.End();
        }

        #endregion

        #region Tile Utility
        
        /// <summary>
        /// Gets the tile at a given coordinate, null if coordinate is out of range.
        /// </summary>
        private Tile GetTile(int x, int y)
        {
            Tile result = null;

            if (x >= 0 && x < tiles.GetLength(0) &&
                y >= 0 && y < tiles.GetLength(1))
            {
                result = tiles[x,y];
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

            tiles = result;
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
