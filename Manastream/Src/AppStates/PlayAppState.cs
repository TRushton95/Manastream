namespace Manastream.Src.AppStates
{
    #region Usings

    using Manastream.Src.Gameplay.Entities;
    using Manastream.Src.Utility;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The appstate for the gameplay
    /// </summary>
    public class PlayAppState : AppState
    {
        #region Fields

        private SpriteBatch gameSpriteBatch;
        private Board board;
        private Camera camera;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PlayAppState"/> class.
        /// </summary>
        public PlayAppState()
        {
            gameSpriteBatch = new SpriteBatch(Resources.GraphicsDevice);

            camera = new Camera(0, 0);
            board = new Board();
            board.Generate();
        }

        #endregion

        public override void Update()
        {
            camera.Update();

            Point transformedMouse = Vector2.Transform(
                MouseInfo.Position.ToVector2(),
                Matrix.Invert(camera.GetTranslationMatrix())).ToPoint();

            board.Update(transformedMouse);
        }

        /// <summary>
        /// Draws the appstate.
        /// The gameplay is drawn with a translated matrix obtained from the camera.
        /// The user interface is overlayed with no translation.
        /// </summary>
        public override void DrawState(SpriteBatch uiSpriteBatch)
        {
            gameSpriteBatch.Begin(transformMatrix: camera.GetTranslationMatrix());

            board.Draw(gameSpriteBatch);

            gameSpriteBatch.End();

            base.DrawState(uiSpriteBatch);
        }
    }
}
