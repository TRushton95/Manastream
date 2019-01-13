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

                case TargetType.EmptyTile:
                    result = ValidateEmptyTile(caster, targetTile);
                    break;

                case TargetType.Unit:
                    result = ValidateUnit(caster, targetTile);
                    break;

                case TargetType.Self:
                    result = ValidateSelf(caster, targetTile);
                    break;

                case TargetType.Enemy:
                    result = ValidateEnemy(caster, targetTile);
                    break;

                case TargetType.Ally:
                    result = ValidateAlly(caster, targetTile);
                    break;
            }

            return result;
        }

        /// <summary>
        /// Gets a value indicating whether the tile is empty.
        /// </summary>
        private static bool ValidateEmptyTile(Unit caster, Tile targetTile)
        {
            if (targetTile.Occupant == null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a value indicating whether the tile contains a unit.
        /// </summary>
        private static bool ValidateUnit(Unit caster, Tile targetTile)
        {
            if (targetTile.Occupant != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a value indicating whether the tile contains the caster.
        /// </summary>
        private static bool ValidateSelf(Unit caster, Tile targetTile)
        {
            Unit occupant = targetTile.Occupant;

            if (occupant != null && occupant == caster)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a value indicating whether the tile contains an enemy.
        /// </summary>
        private static bool ValidateEnemy(Unit caster, Tile targetTile)
        {
            Unit occupant = targetTile.Occupant;

            if (occupant != null && occupant.Owner.Team != caster.Owner.Team)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a value indicating whether the tile contains an ally.
        /// </summary>
        private static bool ValidateAlly(Unit caster, Tile targetTile)
        {
            Unit occupant = targetTile.Occupant;

            if (occupant != null && occupant.Owner.Team == caster.Owner.Team)
            {
                return true;
            }

            return false;
        }


        #endregion
    }
}
