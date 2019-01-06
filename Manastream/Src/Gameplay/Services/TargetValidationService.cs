namespace Manastream.Src.Gameplay.Services
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.Gameplay.Enums;
    
    #endregion

    /// <summary>
    /// The target validation service that indicates whether a tile meets the target type criteria.
    /// </summary>
    public static class TargetValidationService
    {
        #region Methods

        /// <summary>
        /// Returns a value indicating whether the tile is a valid target based on the target type.
        /// </summary>
        public static bool Validate(Tile targetTile, TargetType targetType, Unit caster)
        {
            if (targetTile == null)
            {
                return false;
            }

            bool result = false;

            switch (targetType)
            {
                case TargetType.Any:
                    result = true;
                    break;
            }

            return result;
        }

        #endregion
    }
}
