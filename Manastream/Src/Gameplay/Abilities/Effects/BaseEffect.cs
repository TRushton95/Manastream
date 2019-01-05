namespace Manastream.Src.Gameplay.Abilities.Effects
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.Gameplay.Enums;
    using Manastream.Src.Gameplay.Services;

    #endregion

    /// <summary>
    /// The base effect class that defines the base behaviour for effects.
    /// </summary>
    public abstract class BaseEffect
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="BaseEffect"/> class.
        /// </summary>
        public BaseEffect(TargetType targetType, Unit caster)
        {
            this.TargetType = TargetType;
            this.Caster = caster;
        }

        #endregion

        #region Properties

        public TargetType TargetType
        {
            get;
        }

        public Unit Caster
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the effect.
        /// </summary>
        public abstract void Execute(Tile targetTile);

        /// <summary>
        /// Returns a value indicating whether the tile is a valid target based on the target type.
        /// </summary>
        protected bool ValidateTarget(Tile targetTile)
        {
            return TargetValidationService.Validate(targetTile, TargetType, Caster);
        }

        #endregion
    }
}
