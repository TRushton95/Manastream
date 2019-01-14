namespace Manastream.Src.Gameplay.Entities
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities;
    using Manastream.Src.Gameplay.Abilities.Factories;
    using Manastream.Src.Gameplay.Entities.Actors;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The player class that holds information about the player.
    /// </summary>
    public class Player
    {
        #region Fields

        private static readonly int MaxMana = 3;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises an instance of the <see cref="Player"/> class.
        /// </summary>
        public Player(int team)
        {
            this.Team = team;
            this.CurrentMana = 0;
            this.PowerCaster = new Unit(
                0, 0, this,
                new List<Ability>()
                {
                    AbilityFactory.LightningStrike()
                },
                null);
        }

        #endregion

        #region Properties

        public int Team
        {
            get;
        }

        public int CurrentMana
        {
            get;
            set;
        }

        public Unit PowerCaster
        {
            get;
            set;
        }

        #endregion

        #region Methods
        
        public Ability GetAbility(int index)
        {
            return PowerCaster.Abilities[index];
        }

        #endregion
    }
}
