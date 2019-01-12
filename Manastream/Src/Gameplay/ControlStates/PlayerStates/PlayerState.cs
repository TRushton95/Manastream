namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
{
    #region Usings

    using Manastream.Src.Gameplay.Entities;
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The base player state class that represents a state of interface for a player on the board.
    /// </summary>
    public abstract class PlayerState : ControlState
    {
        #region Fields

        protected readonly int team;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PlayerState"/> class.
        /// </summary>
        public PlayerState(int team, Unit selectedUnit)
        {
            this.team = team;
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

            if (SelectedUnit != null)
            {
                SelectedUnitTile = board.GetTile(SelectedUnit.BoardX, SelectedUnit.BoardY);
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

            if (SelectedUnitTile != null)
            {
                spriteBatch.Draw(Textures.UnitSelect, new Vector2(SelectedUnitTile.CanvasX, SelectedUnitTile.CanvasY), Color.White);
            }
        }

        #endregion
    }
}
