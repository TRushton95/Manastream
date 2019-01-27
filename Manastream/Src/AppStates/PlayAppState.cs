namespace Manastream.Src.AppStates
{
    #region Usings

    using Manastream.Src.EventSystem.Events.Debug;
    using Manastream.Src.Gameplay.Abilities;
    using Manastream.Src.Gameplay.Abilities.Factories;
    using Manastream.Src.Gameplay.ControlStates.PlayerStates;
    using Manastream.Src.Gameplay.Entities;
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Graphics;
    using Manastream.Src.UI;
    using Manastream.Src.UI.Components;
    using Manastream.Src.UI.Components.Complex;
    using Manastream.Src.UI.Enums;
    using Manastream.Src.UI.PositionProfiles;
    using Manastream.Src.Utility;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The appstate for the gameplay
    /// </summary>
    public class PlayAppState : AppState
    {
        #region Fields

        private SpriteBatch gameSpriteBatch;
        private Camera camera;
        private Matrix cameraMatrix;
        private PlayerState playerState;
        private Board board;
        private Dictionary<int, Player> players;
        private int currentTeam, turn;
        private readonly int teamCount;
        private UserInterface ui;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PlayAppState"/> class.
        /// </summary>
        public PlayAppState()
        {
            gameSpriteBatch = new SpriteBatch(Resources.GraphicsDevice);
            camera = new Camera(0, 0);
            teamCount = 2;
            players = new Dictionary<int, Player>();

            for (int i = 1; i <= teamCount; i++)
            {
                players.Add(i, new Player(i));
            }

            board = new Board();
            board.Generate();
            SpawnTestUnits();

            InitialiseTurns();
            playerState = new UnselectedPlayerState(players[currentTeam]);

            Button button = new Button(200, 50, "End turn", new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, 10), 0);

            ui = new UserInterface();
            ui.Components.Add(button);
            ui.Initialise();
        }

        #endregion

        /// <summary>
        /// Updates the app state.
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            camera.Update();
            cameraMatrix = Matrix.Multiply(camera.GetScaleMatrix(), camera.GetTranslationMatrix());
            Point transformedMouse = Vector2.Transform(MouseInfo.Position.ToVector2(), Matrix.Invert(cameraMatrix)).ToPoint();

            PlayerState newPlayerState = playerState.ProcessInput(board, transformedMouse);
            if (newPlayerState != playerState)
            {
                playerState.OnLeave();
                playerState = newPlayerState;
                playerState.OnEnter();
            }

            board.Update(gameTime);

            //DEBUG - Temporary until KeyboardInfo is added
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) && MouseInfo.RightMousePressed)
            {
                NextTurn();
            }
            
            ui.UpdateHoveredComponent();
        }

        /// <summary>
        /// Draws the appstate.
        /// The gameplay is drawn with a translated matrix obtained from the camera.
        /// The user interface is overlayed with no translation.
        /// </summary>
        public override void DrawState(SpriteBatch uiSpriteBatch)
        {
            gameSpriteBatch.Begin(transformMatrix: cameraMatrix);
            board.Draw(gameSpriteBatch);
            playerState.Draw(gameSpriteBatch);
            gameSpriteBatch.End();

            ui.Draw(uiSpriteBatch);
        }

        /// <summary>
        /// Spawns the test units for debugging.
        /// </summary>
        private void SpawnTestUnits()
        {
            Unit wizard = new Unit(
                "Wizard", 10, 3, players[1],
                new List<Ability>()
                {
                    AbilityFactory.Frostbolt()
                },
                new Animation(Unit.Diameter, Unit.Diameter, 1000, 2, Resources.Textures.Wizard));

            Unit knight = new Unit(
                "Knight", 20, 3, players[2],
                new List<Ability>()
                {
                    AbilityFactory.Lunge()
                },
                new Animation(Unit.Diameter, Unit.Diameter, 1000, 2, Resources.Textures.Knight));

            board.TrySpawnUnit(wizard, 2, 5);
            board.TrySpawnUnit(knight, 8, 5);
            board.TrySpawnGenerator(0, 5);
        }

        /// <summary>
        /// Initialises the turn variables.
        /// </summary>
        private void InitialiseTurns()
        {
            turn = 1;
            currentTeam = 1;

            eventManager.Notify(new NewTurnEvent(turn));
            eventManager.Notify(new NewPlayerTurnEvent(players[currentTeam]));
        }

        /// <summary>
        /// Hands control over to the next player.
        /// </summary>
        /// <remarks>DEBUG - This will be invoked as a handler once the user interface is built.</remarks>
        private void NextTurn()
        {
            currentTeam++;

            if (currentTeam > teamCount)
            {
                currentTeam = 1;
                turn++;
                board.ProgressGenerators();

                eventManager.Notify(new NewTurnEvent(turn));
            }

            playerState = new UnselectedPlayerState(players[currentTeam]);
            board.RefreshTeamEnergy(currentTeam);
            board.ActivateTeamTicks(currentTeam);
            
            eventManager.Notify(new NewPlayerTurnEvent(players[currentTeam]));
        }
    }
}
