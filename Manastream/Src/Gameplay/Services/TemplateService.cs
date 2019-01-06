namespace Manastream.Src.Gameplay.Services
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities.Templates;
    using Manastream.Src.Gameplay.Entities;
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

        #region Methods

        /// <summary>
        /// Get the tiles affected by a given template.
        /// </summary>
        public static List<Point> GetAffectedTileCoordinates(Point targetTile, Template template)
        {
            if (targetTile == null || template == null)
            {
                return null;
            }

            List<Point> result = null;

            switch (template.TemplateType)
            {
                case TemplateType.SingleTarget:
                    result = ResolveSingleTargetTemplate(targetTile);
                    break;

                case TemplateType.AreaEffect:
                    result = ResolveAreaEffectTemplate(targetTile, (AreaEffectTemplate)template);
                    break;
            }

            return result;
        }

        #endregion

        #region Template Resolution

        /// <summary>
        /// Gets the tiles affected by the single target template.
        /// </summary>
        public static List<Point> ResolveSingleTargetTemplate(Point targetTile)
        {
            List<Point> result = new List<Point>()
            {
                new Point(targetTile.X, targetTile.Y)
            };

            return result;
        }

        /// <summary>
        /// Gets the tiles affected by the area effect template.
        /// </summary>
        public static List<Point> ResolveAreaEffectTemplate(Point targetTile, AreaEffectTemplate template)
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
                currentTile = Board.TopRight(currentTile);

                foreach (GetAdjacentTile adjacentTile in Board.AdjacentTileMethods)
                {
                    addLineOfTiles(adjacentTile, ringRadius);
                }

                ringRadius++;
            }

            return result;
        }

        #endregion

        #region Utility Methods
        
        /// <summary>
        /// A negative-safe method for determining if an integer is odd.
        /// </summary>
        private static bool IsOdd(int i)
        {
            return Math.Abs(i % 2) == 1;
        }

        #endregion
    }
}
