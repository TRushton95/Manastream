namespace Manastream.Src.Gameplay.PlayerStates
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.Utility;
    using Microsoft.Xna.Framework.Graphics;

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
        /// Processes user input.
        /// </summary>
        public override PlayerState ProcessInput(Tile tile)
        {
            if (MouseInfo.LeftMousePressed)
            {
                if (tile != null && tile.Occupant != null)
                {
                    return new SelectedPlayerState(tile.Occupant);
                }
            }

            return this;
        }

        /// <summary>
        /// Processes user input.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        #endregion
    }
}
