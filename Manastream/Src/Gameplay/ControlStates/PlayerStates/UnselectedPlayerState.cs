namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
{
    #region Usings

    using Manastream.Src.Gameplay.Entities;
    using Manastream.Src.Utility;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The unselected player state class that represents the player interactions when no unit is selected.
    /// </summary>
    public class UnselectedPlayerState : PlayerState
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="UnselectedPlayerState"/> class.
        /// </summary>
        public UnselectedPlayerState(Player player)
            : base(player, null)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes user input.
        /// </summary>
        public override PlayerState ProcessInput(Board board, Point mouse)
        {
            base.ProcessInput(board, mouse);

            if (MouseInfo.LeftMousePressed)
            {
                if (HighlightedUnit != null && HighlightedUnit.Owner.Team == player.Team)
                {
                    return new SelectedPlayerState(player, HighlightedUnit);
                }
            }

            return this;
        }

        /// <summary>
        /// Draws the state.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        #endregion
    }
}
