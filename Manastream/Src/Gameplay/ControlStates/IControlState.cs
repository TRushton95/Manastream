namespace Manastream.Src.Gameplay.ControlStates
{
    #region Usings

    using Manastream.Src.Gameplay.ControlStates.PlayerStates;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The control state interface that defines a contract of how the player must interact with the board
    /// </summary>
    public interface IControlState
    {
        #region Methods

        /// <summary>
        /// Processes user input.
        /// </summary>
        PlayerState ProcessInput();
        
        /// <summary>
        /// Draws the state.
        /// </summary>
        void Draw(SpriteBatch spriteBatch);

        #endregion
    }
}
