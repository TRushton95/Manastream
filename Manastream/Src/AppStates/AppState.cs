namespace Manastream.Src.AppStates
{
    #region Usings

    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The appstate class.
    /// </summary>
    public abstract class AppState
    {
        #region Methods

        /// <summary>
        /// Draws the appstate.
        /// </summary>
        public void DrawState(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
            spriteBatch.End();
        }

        #endregion
    }
}
