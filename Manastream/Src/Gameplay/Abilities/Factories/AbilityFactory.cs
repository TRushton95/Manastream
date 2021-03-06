﻿namespace Manastream.Src.Gameplay.Abilities.Factories
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities.Effects;
    using Manastream.Src.Gameplay.Abilities.Templates;
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Enums;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The ability factory class for constructing preset abilities.
    /// </summary>
    public static class AbilityFactory
    {
        #region Constants

        private const int Melee = 1;
        private const int Global = 999;

        #endregion

        #region Unit Abilities

        /// <summary>
        /// The Frostbolt ability.
        /// </summary>
        public static Ability Frostbolt()
        {
            return new Ability(
                "Frostbolt",
                3,
                TargetType.Enemy,
                new SingleTargetTemplate(),
                new List<BaseEffect>()
                {
                    new InstantDamageEffect(2, TargetType.Enemy)
                });
        }

        public static Ability Lunge()
        {
            /// <summary>
            /// The Lunge ability.
            /// </summary>
            return new Ability(
                "Lunge",
                Melee,
                TargetType.Enemy,
                new SingleTargetTemplate(),
                new List<BaseEffect>()
                {
                    new InstantDamageEffect(5, TargetType.Enemy)
                });
        }

        #endregion

        #region Mana Powers

        /// <summary>
        /// The Lightning Strike power.
        /// </summary>
        public static Ability LightningStrike()
        {
            return new Ability(
                "Lightning Strike",
                Global,
                TargetType.Enemy,
                new SingleTargetTemplate(),
                new List<BaseEffect>()
                {
                    new InstantDamageEffect(20, TargetType.Enemy)
                });
        }

        #endregion
    }
}
