namespace Manastream.Src.Gameplay.PlayerStates
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors.Tiles;

    #endregion

    /// <summary>
    /// The unselected player state class that represents the interactions when no unit is selected.
    /// </summary>
    public class UnselectedPlayerState : PlayerState
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="UnselectedPlayerState"/> class.
        /// </summary>
        public UnselectedPlayerState()
            : base(null)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Resolves tile clicks.
        /// </summary>
        public override PlayerState ClickTile(Tile tile)
        {
            if (tile != null && tile.Occupant != null)
            {
                return new SelectedPlayerState(tile.Occupant);
            }

            return this;
        }

        #endregion
    }
}
