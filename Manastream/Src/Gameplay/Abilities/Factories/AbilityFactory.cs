namespace Manastream.Src.Gameplay.Abilities.Factories
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities.Effects;
    using Manastream.Src.Gameplay.Abilities.Templates;
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Enums;
    using System.Collections.Generic;

    #endregion

    public static class AbilityFactory
    {
        #region Methods

        public static Ability Frostbolt()
        {
            return new Ability(
                "Frostbolt",
                TargetType.Enemy,
                new SingleTargetTemplate(),
                new List<BaseEffect>()
                {
                    new InstantDamageEffect(2, TargetType.Enemy)
                });
        }

        public static Ability Lunge()
        {
            return new Ability(
                "Lunge",
                TargetType.Enemy,
                new SingleTargetTemplate(),
                new List<BaseEffect>()
                {
                    new InstantDamageEffect(5, TargetType.Enemy)
                });
        }

        #endregion
    }
}
