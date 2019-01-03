namespace Manastream.Src.Gameplay.PlayerStates
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.GameResources;
    using Manastream.Src.Utility;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The unselected player state class that represents the interactions when a unit is selected.
    /// </summary>
    public class SelectedPlayerState : PlayerState
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="SelectedPlayerState"/> class.
        /// </summary>
        public SelectedPlayerState(Unit selectedUnit)
            : base(selectedUnit)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes user input.
        /// </summary>
        public override PlayerState ProcessInput(Tile tile)
        {
            if (MouseInfo.LeftMousePressed)
            {
                if (tile != null && tile.Occupant != null)
                {
                    return new SelectedPlayerState(tile.Occupant);
                }

                return new UnselectedPlayerState();
            }

            return this;
        }

        /// <summary>
        /// Processes user input.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D unitHighlightTexture = Resources.GetInstance().Textures.UnitHighlight;

            spriteBatch.Draw(unitHighlightTexture, new Vector2(SelectedUnit.CanvasX, SelectedUnit.CanvasY), Color.White);
        }

        #endregion
    }
}
