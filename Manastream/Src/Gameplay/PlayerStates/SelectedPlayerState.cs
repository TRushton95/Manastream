namespace Manastream.Src.Gameplay.PlayerStates
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;

    #endregion

    /// <summary>
    /// The unselected player state class that represents the interactions when a unit is selected.
    /// </summary>
    public class SelectedPlayerState : PlayerState
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="SelectedPlayerState"/> class.
        /// </summary>
        public SelectedPlayerState(Unit selectedUnit)
            : base(selectedUnit)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Resolves tile clicks.
        /// </summary>
        public override PlayerState ClickTile(Tile tile)
        {
            if (tile != null)
            {
                if (tile.Occupant != this.SelectedUnit)
                {
                    return new SelectedPlayerState(tile.Occupant);
                }

                return this;
            }

            return new UnselectedPlayerState();
        }

        #endregion
    }
}
