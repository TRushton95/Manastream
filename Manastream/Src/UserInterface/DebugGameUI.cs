namespace Manastream.Src.UserInterface
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.EventSystem.Events;
    using Manastream.Src.EventSystem.Events.Debug;
    using Manastream.Src.GameResources;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The debug game UI class for displaying game information easily.
    /// </summary>
    public class DebugGameUI : Listener
    {
        #region Fields

        private Resources resources => Resources.GetInstance();

        private const string TurnMessage = "Turn: {0}";
        private const string PlayerTurnMessage = "Player: {0}";

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="DebugGameUI"/> class.
        /// </summary>
        public DebugGameUI()
        {
            this.Turn = 1;
            this.Player = 1;

            this.InitialiseEventHandlers();
        }

        #endregion

        #region Properties

        public int Turn
        {
            get;
            set;
        }

        public int Player
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the UI.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle window = resources.GraphicsDevice.Viewport.Bounds;
            SpriteFont debugFont = resources.Textures.Debug;

            spriteBatch.DrawString(debugFont, string.Format(TurnMessage, Turn), new Vector2(0, 0), Color.Black);

            float playerTurnMessageLength = debugFont.MeasureString(string.Format(PlayerTurnMessage, Player)).X;
            spriteBatch.DrawString(debugFont, string.Format(PlayerTurnMessage, Player), new Vector2(window.Right - playerTurnMessageLength, 0), Color.Black);
        }

        private void InitialiseEventHandlers()
        {
            AddEventHandler(EventTypes.Debug.NewTurn, OnNewTurn);
            AddEventHandler(EventTypes.Debug.NewPlayerTurn, OnNewPlayerTurn);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// The handler for a new turn event.
        /// </summary>
        public void OnNewTurn(Event e)
        {
            NewTurnEvent args = (NewTurnEvent)e;
            Turn = args.Turn;
        }

        public void OnNewPlayerTurn(Event e)
        {
            NewPlayerTurnEvent args = (NewPlayerTurnEvent)e;
            Player = args.Player;
            
        }

        #endregion
    }
}
