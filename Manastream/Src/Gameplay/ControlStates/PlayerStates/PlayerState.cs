namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
{
    using Manastream.Src.EventSystem.Events.Graphics;
    #region Usings

    using Manastream.Src.Gameplay.Entities;
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.Gameplay.Enums;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    /// <summary>
    /// The base player state class that represents a state of interface for a player on the board.
    /// </summary>
    public abstract class PlayerState : ControlState
    {
        #region Fields

        protected readonly Player player;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PlayerState"/> class.
        /// </summary>
        public PlayerState(Player player, Unit selectedUnit)
        {
            this.player = player;
            this.SelectedUnit = selectedUnit;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes user input.
        /// </summary>
        public override PlayerState ProcessInput(Board board, Point mouse)
        {
            base.ProcessInput(board, mouse);

            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                return new PowerPlayerState(player, player.GetAbility(0));
            }

            if (SelectedUnit != null)
            {
                SelectedUnitTile = board.GetTile(SelectedUnit.BoardPosition.X, SelectedUnit.BoardPosition.Y);
            }

            return null;
        }

        #endregion

        #region Properties

        public Unit SelectedUnit
        {
            get;
        }

        public Tile SelectedUnitTile
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the state.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (HighlightedTile != null && HighlightedTile.Occupant != null)
            {
                Texture2D highlight = HighlightedTile.Occupant.Owner.Team == player.Team ? Textures.AllyTileHighlight : Textures.EnemyTileHighlight;
                
                eventManager.Notify(new TextureDrawReadyEvent(highlight, HighlightedTile.CanvasPosition.ToVector2(), DrawLayer.Game));
            }

            if (SelectedUnitTile != null)
            {
                eventManager.Notify(new TextureDrawReadyEvent(Textures.UnitSelect, SelectedUnitTile.CanvasPosition.ToVector2(), DrawLayer.Game));
            }
        }

        #endregion
    }
}
