namespace Manastream.Src.Gameplay.Abilities
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities.Effects;
    using Manastream.Src.Gameplay.Abilities.Templates;
    using Manastream.Src.Gameplay.Enums;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The ability class.
    /// </summary>
    public class Ability
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Ability"/> class.
        /// </summary>
        public Ability(string name, TargetType targetType, Template template, List<BaseEffect> effects)
        {
            this.Name = name;
            this.TargetType = targetType;
            this.Template = template;
            this.Effects = effects;
        }

        #endregion

        #region Properties

        public string Name
        {
            get;
        }

        public TargetType TargetType
        {
            get;
        }

        public Template Template
        {
            get;
        }

        public List<BaseEffect> Effects
        {
            get;
        }

        #endregion
    }
}
