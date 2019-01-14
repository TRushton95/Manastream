namespace Manastream.Src.Gameplay.ControlStates
{
    using Manastream.Src.EventSystem;
    using Manastream.Src.EventSystem.Events.Debug;
    #region Usings

    using Manastream.Src.Gameplay.ControlStates.PlayerStates;
    using Manastream.Src.Gameplay.Entities;
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.GameResources;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The control state interface that defines a contract of how the player interacts with the board
    /// </summary>
    public abstract class ControlState : Listener
    {
        #region Fields

        private Textures textures = Resources.GetInstance().Textures;

        #endregion

        #region Properties

        protected Tile HighlightedTile
        {
            get;
            set;
        }

        protected Unit HighlightedUnit
        {
            get;
            set;
        }

        protected Unit PreviousHighlightedUnit
        {
            get;
            set;
        }

        protected Textures Textures => textures;

        #endregion

        #region Methods

        /// <summary>
        /// Processes user input.
        /// </summary>
        public virtual PlayerState ProcessInput(Board board, Point mouse)
        {
            HighlightedTile = board.GetTileAtCanvasPosition(mouse.X, mouse.Y);

            PreviousHighlightedUnit = HighlightedUnit;

            if (HighlightedTile != null)
            {
                HighlightedUnit = HighlightedTile.Occupant;
            }

            if (PreviousHighlightedUnit != HighlightedUnit)
            {
                eventManager.Notify(new HighlightUnitEvent(HighlightedUnit));
            }

            return null;
        }

        /// <summary>
        /// Logic to do when entering the control state.
        /// </summary>
        public virtual void OnEnter() { }

        /// <summary>
        /// Logic to do when leaving the control state.
        /// </summary>
        public virtual void OnLeave() { }
        
        /// <summary>
        /// Draws the state.
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (HighlightedTile != null)
            {
                spriteBatch.Draw(Textures.TileHighlight, new Vector2(HighlightedTile.CanvasX, HighlightedTile.CanvasY), Color.White);
            }
        }

        #endregion
    }
}
