namespace Manastream.Src.Gameplay.Entities
{
    using Manastream.Src.Gameplay.Abilities.Ticks;
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.GameResources;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    #region Delegates

    public delegate Point GetAdjacentTile(Point tile);

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

        public static GetAdjacentTile[] AdjacentTileMethods => new GetAdjacentTile[6] {
                BottomRight,
                BottomLeft,
                Left,
                TopLeft,
                TopRight,
                Right
        };

        #endregion

        #region Methods

        public void Update(GameTime gameTime)
        {
            foreach (Tile tile in Tiles)
            {
                tile.Update(gameTime);
            }

            foreach (Unit unit in units)
            {
                unit.Update(gameTime);
            }
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

        #region Unit Controls

        /// <summary>
        /// Restores the energy for all units on a given team.
        /// </summary>
        public void RefreshTeamEnergy(int team)
        {
            foreach (Unit unit in units)
            {
                if (unit.Team != team)
                {
                    continue;
                }
                
                unit.CurrentEnergy = unit.MaxEnergy;
            }
        }

        /// <summary>
        /// Activates the ticks for all units on a given team.
        /// </summary>
        public void ActivateTeamTicks(int team)
        {
            foreach (Unit unit in units)
            {
                if (unit.Team != team)
                {
                    continue;
                }

                foreach (BaseTick tick in unit.Ticks)
                {
                    tick.Activate(unit);
                }
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

            Tile destination = GetTile(x, y);
            result = TryRelocateUnit(unit, destination);
            
            if (result == true)
            {
                units.Add(unit);
            }

            return result;
        }

        /// <summary>
        /// Attempt to move a unit to the specified location on the board.
        /// </summary>
        public bool TryMoveUnit(Unit unit, int x, int y)
        {
            bool result = false;

            Tile origin = GetTile(unit.BoardX, unit.BoardY);
            Tile destination = GetTile(x, y);
            List<Tile> path = DijkstraSearch(origin, destination);

            if (path.Count == 0)
            {
                Console.WriteLine("Cannot move there!");

                return false;
            }

            int energyCost = path.Sum(Tile => Tile.MovementCost);

            if (unit.CurrentEnergy >= energyCost)
            {
                if (TryRelocateUnit(unit, destination))
                {
                    unit.CurrentEnergy -= energyCost;
                    Console.WriteLine($"{unit.CurrentEnergy}/{unit.MaxEnergy}");
                    result = true;
                }
            }
            else
            {
                Console.WriteLine("Not enough energy!");
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

                    //DEBUG - default board will be all empty once map creation is added
                    if (IsOdd(y) && IsOdd(x))
                    {
                        result[x, y] = new WaterTile(x, y, canvasX, canvasY);
                    }
                    else
                    {
                        result[x, y] = new GroundTile(x, y, canvasX, canvasY);
                    }
                }
            }

            Tiles = result;
        }

        #endregion

        #region Tile Retrieval

        /// <summary>
        /// Gets the tile at a given coordinate.
        /// Result is null if coordinate is out of range.
        /// </summary>
        public Tile GetTile(int x, int y)
        {
            Tile result = null;

            if (x >= 0 && x < Tiles.GetLength(0) &&
                y >= 0 && y < Tiles.GetLength(1))
            {
                result = Tiles[x, y];
            }

            return result;
        }

        /// <summary>
        /// Gets a list of tiles at the given coordinates.
        /// A tile will not be included if it is out of range.
        /// </summary>
        public List<Tile> GetTiles(List<Point> coordinates)
        {
            List<Tile> result = new List<Tile>();

            foreach (Point point in coordinates)
            {
                Tile tile = (GetTile(point.X, point.Y));

                if (tile != null)
                {
                    result.Add(tile);
                }
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

                if (!rowIsOdd)
                {
                    column--;
                }
            }
            else if (relY < (m * relX) - c) //right edge
            {
                row--;

                if (rowIsOdd)
                {
                    column++;
                }
            }

            result = GetTile(column, row);

            return result;
        }

        /// <summary>
        /// Gets a list of tiles representing the path from the unit to the destination.
        /// </summary>
        public List<Tile> GetUnitPath(Unit unit, Tile destination)
        {
            Tile origin = GetTile(unit.BoardX, unit.BoardY);

            return DijkstraSearch(origin, destination);
        }

        /// <summary>
        /// Gets a list of tiles representing the path of an ability from the unit to the destination.
        /// An ability path differs from a unit path in that it is unaffected by tile movement costs and impassable terrain.
        /// </summary>
        public List<Tile> GetAbilityPath(Unit unit, Tile destination)
        {
            Tile origin = GetTile(unit.BoardX, unit.BoardY);

            return DijkstraSearch(origin, destination, true);
        }

        #endregion

        #region Adjacent Tiles

        /// <summary>
        /// Get the tile coordinates to the top right of a point.
        /// </summary>
        public static Point TopRight(Point tile)
        {
            if (IsOdd(tile.Y))
            {
                return new Point(tile.X + 1, tile.Y - 1);
            }

            return new Point(tile.X, tile.Y - 1);
        }

        /// <summary>
        /// Get the tile coordinates to the bottom right of a point.
        /// </summary>
        public static Point BottomRight(Point tile)
        {
            if (IsOdd(tile.Y))
            {
                return new Point(tile.X + 1, tile.Y + 1);
            }

            return new Point(tile.X, tile.Y + 1);
        }

        /// <summary>
        /// Get the tile coordinates to the bottom left of a point.
        /// </summary>
        public static Point BottomLeft(Point tile)
        {
            if (IsOdd(tile.Y))
            {
                return new Point(tile.X, tile.Y + 1);
            }

            return new Point(tile.X - 1, tile.Y + 1);
        }

        /// <summary>
        /// Get the tile coordinates to the left of a point.
        /// </summary>
        public static Point Left(Point tile)
        {
            return new Point(tile.X - 1, tile.Y);
        }

        /// <summary>
        /// Get the tile coordinates to the top left of a point.
        /// </summary>
        public static Point TopLeft(Point tile)
        {
            if (IsOdd(tile.Y))
            {
                return new Point(tile.X, tile.Y - 1);
            }

            return new Point(tile.X - 1, tile.Y - 1);
        }

        /// <summary>
        /// Get the tile coordinates to the right of a point.
        /// </summary>
        public static Point Right(Point tile)
        {
            return new Point(tile.X + 1, tile.Y);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// The Dikstra Seach algorithm that returns a list of tiles representing the most efficient path from an origin to a destination.
        /// Interactive argument determines whether the ability is affected by movement cost, traversable, etc.
        /// </summary>
        private List<Tile> DijkstraSearch(Tile origin, Tile destination, bool ignoreEnvironment = false)
        {
            //Initialisation
            DijkstraNode originNode, destinationNode;

            List<DijkstraNode> unvisitedNodes = new List<DijkstraNode>();
            List<DijkstraNode> distance = new List<DijkstraNode>();

            foreach (Tile tile in Tiles)
            {
                int cost = int.MaxValue;

                DijkstraNode newNode = new DijkstraNode(tile, cost);

                if (tile == origin)
                {
                    newNode.cost = 0;
                    originNode = newNode;
                }

                if (tile == destination)
                {
                    destinationNode = newNode;
                }

                distance.Add(newNode);
                unvisitedNodes.Add(newNode);
            }

            Tile currentTile = origin;

            //Algorithm
            while (unvisitedNodes.Count > 0)
            {
                List<Tile> adjacentTiles = GetTiles(AdjacentTileMethods.Select(method => method(currentTile.BoardPosition)).ToList());
                List<DijkstraNode> adjacentNodes = distance.Where(node => adjacentTiles.Contains(node.tile)).ToList();
                List<DijkstraNode> unvisitedAdjacentNodes;

                if (ignoreEnvironment)
                {
                    unvisitedAdjacentNodes = adjacentNodes.Where(node => !node.visited).ToList();
                }
                else
                {
                    unvisitedAdjacentNodes = adjacentNodes.Where(node => !node.visited && node.tile.Traversable && node.tile.Occupant == null).ToList();
                }

                DijkstraNode currentNode = distance.Single(node => node.tile == currentTile);

                foreach (DijkstraNode adjacentNode in unvisitedAdjacentNodes)
                {
                    int tileCost = ignoreEnvironment ? 1: adjacentNode.tile.MovementCost;
                    int cost = currentNode.cost + tileCost;
                    
                    if (cost < adjacentNode.cost)
                    {
                        adjacentNode.cost = cost;
                        adjacentNode.parent = currentNode;
                    }
                }

                //Mark node as visited?
                currentNode.visited = true;
                unvisitedNodes.Remove(currentNode);

                if (currentTile == destination)
                {
                    break;
                }

                currentTile = distance.Where(node => !node.visited).OrderBy(node => node.cost).First().tile;
            }

            DijkstraNode reverseSearchNode = distance.Single(node => node.tile == currentTile);
            List<Tile> path = new List<Tile>();

            while (reverseSearchNode != null)
            {
                path.Add(reverseSearchNode.tile);
                reverseSearchNode = reverseSearchNode.parent;
            }

            path.Reverse();
            path.RemoveAt(0);

            return path;
        }

        /// <summary>
        /// Attempt to move a unit to the new destination tile.
        /// </summary>
        private bool TryRelocateUnit(Unit unit, Tile destination)
        {
            if (!destination.Traversable || destination.Occupant != null)
            {
                Console.WriteLine("Cannot place a unit there!");
                return false;
            }

            bool result = false;

            if (destination != null && destination.Occupant == null)
            {
                Tile origin = GetTile(unit.BoardX, unit.BoardY);
                origin.Occupant = null;
                destination.Occupant = unit;

                unit.BoardX = destination.BoardX;
                unit.BoardY = destination.BoardY;
                unit.CanvasX = destination.CanvasX + (Tile.Diameter / 2) - (Unit.Diameter / 2);
                unit.CanvasY = destination.CanvasY + (Tile.Diameter / 2) - (Unit.Diameter / 2);

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Determines whether an integer is odd.
        /// </summary>
        private static bool IsOdd(int i)
        {
            return Math.Abs(i % 2) == 1;
        }

        #endregion

        #region Internal Classes

        /// <summary>
        /// The node class used in the Dijkstra Search algorithm.
        /// </summary>
        private class DijkstraNode
        {
            public DijkstraNode(Tile tile, int cost)
            {
                this.tile = tile;
                this.cost = cost;
                this.visited = false;
                this.parent = null;
            }

            public Tile tile;
            public int cost;
            public bool visited;
            public DijkstraNode parent;
        }

        #endregion
    }

}
