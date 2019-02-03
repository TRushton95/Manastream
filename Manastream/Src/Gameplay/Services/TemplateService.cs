namespace Manastream.Src.Gameplay.Services
{
    #region Usings

    using Manastream.Src.DataStructures;
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
        public static List<Position> GetAffectedTileCoordinates(Position targetTilePosition, Template template)
        {
            if (targetTilePosition == null || template == null)
            {
                return null;
            }

            List<Position> result = null;

            switch (template.TemplateType)
            {
                case TemplateType.SingleTarget:
                    result = ResolveSingleTargetTemplate(targetTilePosition);
                    break;

                case TemplateType.AreaEffect:
                    result = ResolveAreaEffectTemplate(targetTilePosition, (AreaEffectTemplate)template);
                    break;
            }

            return result;
        }

        #endregion

        #region Template Resolution

        /// <summary>
        /// Gets the tiles affected by the single target template.
        /// </summary>
        public static List<Position> ResolveSingleTargetTemplate(Position targetTilePosition)
        {
            List<Position> result = new List<Position>()
            {
                new Position(targetTilePosition.X, targetTilePosition.Y)
            };

            return result;
        }

        /// <summary>
        /// Gets the tiles affected by the area effect template.
        /// </summary>
        public static List<Position> ResolveAreaEffectTemplate(Position targetTilePosition, AreaEffectTemplate template)
        {
            List<Position> result = new List<Position>();

            Position currentTilePosition = targetTilePosition;

            Action<GetAdjacentTile, int> addLineOfTiles = (GetAdjacentTile getAdjacentTile, int length) =>
            {
                for (int j = 0; j < length; j++)
                {
                    result.Add(currentTilePosition);
                    currentTilePosition = getAdjacentTile(currentTilePosition);
                }
            };

            result.Add(currentTilePosition);

            int ringRadius = 1;
            for (int i = 0; i < template.Radius; i++)
            {
                currentTilePosition = Board.TopRight(currentTilePosition);

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
