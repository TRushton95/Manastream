﻿namespace Manastream.Src.AppStates
{
    #region Usings

    using Manastream.Src.Gameplay.ControlStates.PlayerStates;
    using Manastream.Src.Gameplay.Entities;
    using Manastream.Src.Gameplay.Entities.Actors;
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
        private Camera camera;
        private PlayerState playerState;
        private Board board;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PlayAppState"/> class.
        /// </summary>
        public PlayAppState()
        {
            gameSpriteBatch = new SpriteBatch(Resources.GraphicsDevice);
            camera = new Camera(0, 0);
            playerState = new UnselectedPlayerState();
            
            board = new Board();
            board.Generate();
            board.TrySpawnUnit(new Unit(Resources.Textures.BlueUnit), 2, 5);
        }

        #endregion

        /// <summary>
        /// Updates the app state.
        /// </summary>
        public override void Update()
        {
            camera.Update();

            Point transformedMouse = Vector2.Transform(MouseInfo.Position.ToVector2(), Matrix.Invert(camera.GetTranslationMatrix())).ToPoint();
            playerState = playerState.ProcessInput(board, transformedMouse);
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
            playerState.Draw(gameSpriteBatch);
            gameSpriteBatch.End();

            base.DrawState(uiSpriteBatch);
        }
    }
}