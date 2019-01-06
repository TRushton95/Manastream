namespace Manastream.Src.Gameplay.Abilities.Effects
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities.Ticks;
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.Gameplay.Enums;

    #endregion

    /// <summary>
    /// The damage over time effect class that applies a damage tick.
    /// </summary>
    public class DamageOverTimeEffect : BaseEffect
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="DamageOverTimeEffect"/> class.
        /// </summary>
        public DamageOverTimeEffect(int value, int duration, TargetType targetType)
            : base(targetType)
        {
            this.Value = value;
            this.Duration = duration;
        }

        #endregion

        #region Properties

        public int Value
        {
            get;
        }

        public int Duration
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
            if (!ValidateTarget(targetTile, caster))
            {
                return;
            }

            targetTile.Occupant.Ticks.Add(new DamageTick(Value, Duration));
        }

        #endregion
    }
}
