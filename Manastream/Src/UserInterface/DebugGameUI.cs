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
        private const string UnitProfileMessage = "{0}\nHealth: {1}/{2}\nEnergy{3}/{4}";

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="DebugGameUI"/> class.
        /// </summary>
        public DebugGameUI()
        {
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

            spriteBatch.DrawString(debugFont, string.Format(PlayerTurnMessage, Player.Team), new Vector2(0, 0), Color.Black);

            float turnMessageLength = debugFont.MeasureString(string.Format(TurnMessage, Turn)).X;
            spriteBatch.DrawString(debugFont, string.Format(TurnMessage, Turn), new Vector2(window.Right - turnMessageLength, 0), Color.Black);

            if (HighlightedUnit != null)
            {
                string highlightedUnitProfileMessage = string.Format(UnitProfileMessage, HighlightedUnit.Name,
                        HighlightedUnit.CurrentHealth, HighlightedUnit.MaxHealth,
                        HighlightedUnit.CurrentEnergy, HighlightedUnit.MaxEnergy);

                spriteBatch.DrawString(debugFont, highlightedUnitProfileMessage,
                    new Vector2(0, window.Height - debugFont.MeasureString(highlightedUnitProfileMessage).Y), Color.Black);
            }

            if (SelectedUnit != null)
            {
                string selectedUnitProfileMessage = string.Format(UnitProfileMessage, SelectedUnit.Name,
                        SelectedUnit.CurrentHealth, SelectedUnit.MaxHealth,
                        SelectedUnit.CurrentEnergy, SelectedUnit.MaxEnergy);

                spriteBatch.DrawString(debugFont, selectedUnitProfileMessage,
                    new Vector2(window.Width - debugFont.MeasureString(selectedUnitProfileMessage).X, window.Height - debugFont.MeasureString(selectedUnitProfileMessage).Y), Color.Black);
            }
        }

        private void InitialiseEventHandlers()
        {
            AddEventHandler(EventTypes.Debug.NewTurn, OnNewTurn);
            AddEventHandler(EventTypes.Debug.NewPlayerTurn, OnNewPlayerTurn);
            AddEventHandler(EventTypes.Debug.HighlightUnit, OnHighlightUnit);
            AddEventHandler(EventTypes.Debug.SelectUnit, OnSelectUnit);
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

        public void OnHighlightUnit(Event e)
        {
            HighlightUnitEvent args = (HighlightUnitEvent)e;
            HighlightedUnit = args.HighlightedUnit;
        }

        public void OnSelectUnit(Event e)
        {
            SelectUnitEvent args = (SelectUnitEvent)e;
            SelectedUnit = args.SelectedUnit;
        }

        #endregion
    }
}
