namespace Manastream.Src.Gameplay.Entities.Actors
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities;
    using Manastream.Src.Gameplay.Abilities.Ticks;
    using Manastream.Src.Gameplay.Entities.Actor;
    using Manastream.Src.Gameplay.Graphics;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The unit class.
    /// </summary>
    public class Unit : GameActor
    {
        #region Constants

        public const int Diameter = 50;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Unit"/> class.
        /// </summary>
        public Unit(int maxHealth, List<Ability> abilities, Animation animation)
            : base(0, 0, 0, 0, animation)
        {
            this.MaxHealth = maxHealth;
            this.CurrentHealth = maxHealth;
            this.Abilities = abilities;
            this.Ticks = new List<BaseTick>();
        }

        #endregion

        #region Properties

        public int MaxHealth
        {
            get;
            set;
        }

        public int CurrentHealth
        {
            get;
            set;
        }

        public List<Ability> Abilities
        {
            get;
            set;
        }

        public List<BaseTick> Ticks
        {
            get;
            set;
        }

        #endregion
    }
}
