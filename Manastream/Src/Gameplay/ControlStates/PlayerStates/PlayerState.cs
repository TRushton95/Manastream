namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.GameResources;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The base player state class that represents a state of interface for a player on the board.
    /// </summary>
    public abstract class PlayerState : ControlState
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PlayerState"/> class.
        /// </summary>
        public PlayerState(Unit selectedUnit)
        {
            this.SelectedUnit = selectedUnit;
        }

        #endregion

        #region Properties

        public Unit SelectedUnit
        {
            get;
        }

        #endregion
    }
}
