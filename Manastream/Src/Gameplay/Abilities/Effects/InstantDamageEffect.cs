﻿namespace Manastream.Src.Gameplay.Abilities.Effects
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.Gameplay.Enums;

    #endregion

    /// <summary>
    /// The instant damage effect class.
    /// </summary>
    public class InstantDamageEffect : BaseEffect
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="InstantDamageEffect"/> class.
        /// </summary>
        public InstantDamageEffect(int value, TargetType targetType, Unit caster)
            : base(targetType, caster)
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
        public override void Execute(Tile targetTile)
        {
            if (ValidateTarget(targetTile))
            {
                AtomicEffects.Damage(targetTile.Occupant, Value);
            }
        }

        #endregion
    }
}
