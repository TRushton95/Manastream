namespace Manastream.Src.AppStates
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.GameResources;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The appstate class.
    /// </summary>
    public abstract class AppState : Listener
    {
        #region Properties

        protected Resources Resources => Resources.GetInstance();

        #endregion

        #region Methods

        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Draws the appstate.
        /// </summary>
        public abstract void DrawState(SpriteBatch uiSpriteBatch);

        #endregion
    }
}
