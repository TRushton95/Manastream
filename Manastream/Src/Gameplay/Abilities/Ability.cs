namespace Manastream.Src.Gameplay.Abilities
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities.Effects;
    using Manastream.Src.Gameplay.Abilities.Templates;
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.Gameplay.Enums;
    using Manastream.Src.Gameplay.Services;
    using System;
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
        public Ability(string name, int range, TargetType targetType, Template template, List<BaseEffect> effects)
        {
            this.Name = name;
            this.Range = range;
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

        public int Range
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

        #region Methods

        /// <summary>
        /// Execute the ability on the target tile and return a value indicating whether it was successful.
        /// </summary>
        public bool Execute(Tile targetTile, List<Tile> affectedTiles, Unit caster)
        {
            foreach (Tile tile in affectedTiles)
            {
                foreach (BaseEffect effect in Effects)
                {
                    effect.Execute(tile, caster);
                }
            }

            //DEBUG
            Console.WriteLine("Ability executed");

            return true;
        }

        #endregion
    }
}
