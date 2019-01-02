namespace Manastream.Src.AppStates
{
    #region Usings

    using Manastream.Src.GameResources;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The appstate class.
    /// </summary>
    public abstract class AppState
    {
        #region Properties

        protected Resources Resources => Resources.GetInstance();

        #endregion

        #region Methods

        public abstract void Update();

        /// <summary>
        /// Draws the appstate.
        /// </summary>
        public virtual void DrawState(SpriteBatch uiSpriteBatch)
        {
            uiSpriteBatch.Begin();
            
            uiSpriteBatch.End();
        }

        #endregion
    }
}
