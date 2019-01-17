namespace Manastream.Src.UserInterface
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.EventSystem.Events;
    using Manastream.Src.EventSystem.Events.Debug;
    using Manastream.Src.Gameplay.Entities;
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.GameResources;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Timers;

    #endregion

    /// <summary>
    /// The debug game UI class for displaying game information easily.
    /// </summary>
    public class DebugGameUI : Listener
    {
        #region Constants

        private const int AlertDuration = 3000;
        private const string TurnMessage = "Turn: {0}";
        private const string PlayerProfile = "Player: {0}\nMana: {1}";
        private const string UnitProfile = "{0}\nHealth: {1}/{2}\nEnergy: {3}/{4}";

        #endregion

        #region Fields

        private Resources resources => Resources.GetInstance();
        private Timer alertTimer;
        private string alertMessage;
        private bool showAlert;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="DebugGameUI"/> class.
        /// </summary>
        public DebugGameUI()
        {
            alertTimer = new Timer(AlertDuration);
            alertTimer.Elapsed += OnAlertTimerExpire;
            alertTimer.AutoReset = false;

            this.InitialiseEventHandlers();
        }

        #endregion

        #region Properties

        public int Turn
        {
            get;
            set;
        }

        public Player Player
        {
            get;
            set;
        }

        public Unit HighlightedUnit
        {
            get;
            set;
        }

        public Unit SelectedUnit
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

            spriteBatch.DrawString(debugFont, string.Format(PlayerProfile, Player.Team, Player.CurrentMana), new Vector2(0, 0), Color.Black);

            float turnMessageLength = debugFont.MeasureString(string.Format(TurnMessage, Turn)).X;
            spriteBatch.DrawString(debugFont, string.Format(TurnMessage, Turn), new Vector2(window.Right - turnMessageLength, 0), Color.Black);

            if (HighlightedUnit != null)
            {
                string highlightedUnitProfileMessage = string.Format(UnitProfile, HighlightedUnit.Name,
                        HighlightedUnit.CurrentHealth, HighlightedUnit.MaxHealth,
                        HighlightedUnit.CurrentEnergy, HighlightedUnit.MaxEnergy);

                spriteBatch.DrawString(debugFont, highlightedUnitProfileMessage,
                    new Vector2(0, window.Height - debugFont.MeasureString(highlightedUnitProfileMessage).Y), Color.Black);
            }

            if (SelectedUnit != null)
            {
                string selectedUnitProfileMessage = string.Format(UnitProfile, SelectedUnit.Name,
                        SelectedUnit.CurrentHealth, SelectedUnit.MaxHealth,
                        SelectedUnit.CurrentEnergy, SelectedUnit.MaxEnergy);

                spriteBatch.DrawString(debugFont, selectedUnitProfileMessage,
                    new Vector2(window.Width - debugFont.MeasureString(selectedUnitProfileMessage).X, window.Height - debugFont.MeasureString(selectedUnitProfileMessage).Y), Color.Black);
            }

            if (showAlert)
            {
                Vector2 alertDimensions = debugFont.MeasureString(alertMessage);
                spriteBatch.DrawString(debugFont, alertMessage, new Vector2((window.Width / 2) - (alertDimensions.X / 2), 100), Color.Red);
            }
        }

        /// <summary>
        /// Initialises the event handlers.
        /// </summary>
        private void InitialiseEventHandlers()
        {
            AddEventHandler(EventTypes.Debug.NewTurn, OnNewTurn);
            AddEventHandler(EventTypes.Debug.NewPlayerTurn, OnNewPlayerTurn);
            AddEventHandler(EventTypes.Debug.HighlightUnit, OnHighlightUnit);
            AddEventHandler(EventTypes.Debug.SelectUnit, OnSelectUnit);
        }

        /// <summary>
        /// Changes the alert message and begins the alert timer.
        /// </summary>
        private void DisplayAlert(string message)
        {
            if (alertTimer.Enabled)
            {
                alertTimer.Stop();
            }

            alertMessage = message;
            alertTimer.Start();
        }

        /// <summary>
        /// The callback handler for the alert timer.
        /// </summary>
        private void OnAlertTimerExpire(object source, ElapsedEventArgs e)
        {
            showAlert = false;
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

        /// <summary>
        /// The handler for a new player turn event.
        /// </summary>
        public void OnNewPlayerTurn(Event e)
        {
            NewPlayerTurnEvent args = (NewPlayerTurnEvent)e;
            Player = args.Player;
            
        }

        /// <summary>
        /// The handler for a highlight unit event.
        /// </summary>
        public void OnHighlightUnit(Event e)
        {
            HighlightUnitEvent args = (HighlightUnitEvent)e;
            HighlightedUnit = args.HighlightedUnit;
        }

        /// <summary>
        /// The handler for a select unit event.
        /// </summary>
        public void OnSelectUnit(Event e)
        {
            SelectUnitEvent args = (SelectUnitEvent)e;
            SelectedUnit = args.SelectedUnit;
        }

        #endregion
    }
}
