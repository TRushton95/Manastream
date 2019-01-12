namespace Manastream.Src.Gameplay.Abilities.Effects
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.Gameplay.Enums;
    
    #endregion

    /// <summary>
    /// The instant damage effect class.
    /// </summary>
    public class InstantHealEffect : BaseEffect
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="InstantHealEffect"/> class.
        /// </summary>
        public InstantHealEffect(int value, TargetType targetType)
            : base(targetType)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        public int Value
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the effect.
        /// </summary>
        public override void Execute(Tile targetTile, Unit caster)
        {
            if (ValidateTarget(targetTile, caster))
            {
                AtomicEffects.Heal(targetTile.Occupant, Value);
            }
        }

        #endregion
    }
}
