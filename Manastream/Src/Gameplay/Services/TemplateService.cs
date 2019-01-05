namespace Manastream.Src.Gameplay.Services
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities.Templates;
    using Manastream.Src.Gameplay.Enums;
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The template service that allows gathering of potential affected tile coordinates for templates.
    /// </summary>
    public static class TemplateService
    {
        #region Delegates
        
        private delegate Point GetAdjacentTile(Point tile);

        #endregion

        #region Fields

        private static readonly GetAdjacentTile[] adjacentTileMethods = new GetAdjacentTile[6] {
                BottomRight,
                BottomLeft,
                Left,
                TopLeft,
                TopRight,
                Right
        };

        #endregion

        #region Methods

        /// <summary>
        /// Get the tiles affected by a given template.
        /// </summary>
        public static Point[] GetTilesFromTemplate(Point targetTile, Template template)
        {
            if (targetTile == null || template == null)
            {
                return null;
            }

            Point[] result = null;

            switch (template.TemplateType)
            {
                case TemplateType.AreaEffect:
                    result = ResolveAreaEffectTemplate(targetTile, (AreaEffectTemplate)template);
                    break;
            }

            return result;
        }

        /// <summary>
        /// A negative-safe method for determining if an integer is odd.
        /// </summary>
        private static bool IsOdd(int i)
        {
            return Math.Abs(i % 2) == 1;
        }

        #endregion

        #region Template Resolution

        /// <summary>
        /// Gets the tiles affected by the area effect template
        /// </summary>
        public static Point[] ResolveAreaEffectTemplate(Point targetTile, AreaEffectTemplate template)
        {
            List<Point> result = new List<Point>();

            Point currentTile = targetTile;

            Action<GetAdjacentTile, int> addLineOfTiles = (GetAdjacentTile getAdjacentTile, int length) =>
            {
                for (int j = 0; j < length; j++)
                {
                    result.Add(currentTile);
                    currentTile = getAdjacentTile(currentTile);
                }
            };

            result.Add(currentTile);

            int ringRadius = 1;
            for (int i = 0; i < template.Radius; i++)
            {
                currentTile = TopRight(currentTile);

                foreach (GetAdjacentTile adjacentTile in adjacentTileMethods)
                {
                    addLineOfTiles(adjacentTile, ringRadius);
                }

                ringRadius++;
            }

            return result.ToArray();
        }

        #endregion

        #region Adjacent Tiles

        /// <summary>
        /// Get the tile coordinates to the top right of a point.
        /// </summary>
        private static Point TopRight(Point tile)
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
        private static Point BottomRight(Point tile)
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
        private static Point BottomLeft(Point tile)
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
        private static Point Left(Point tile)
        {
            return new Point(tile.X - 1, tile.Y);
        }

        /// <summary>
        /// Get the tile coordinates to the top left of a point.
        /// </summary>
        private static Point TopLeft(Point tile)
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
        private static Point Right(Point tile)
        {
            return new Point(tile.X + 1, tile.Y);
        }

        #endregion
    }
}
