namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
{
    #region Usings

    using Manastream.Src.Gameplay.Entities;
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.GameResources;
    using Manastream.Src.Utility;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The unselected player state class that represents the player interactions when a unit is selected.
    /// </summary>
    public class SelectedPlayerState : PlayerState
    {
        #region Fields

        List<Tile> path;

        #endregion

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
        public override PlayerState ProcessInput(Board board, Point mouse)
        {
            base.ProcessInput(board, mouse);

            if (MouseInfo.LeftMousePressed)
            {
                if (HighlightedTile?.Occupant == null)
                {
                    return new UnselectedPlayerState();
                }

                if (HighlightedTile?.Occupant != SelectedUnit)
                {
                    return new SelectedPlayerState(HighlightedTile.Occupant);
                }
            }

            path = null;
            if (HighlightedTile != null)
            {
                path = board.GetPath(SelectedUnit, HighlightedTile);

                if (MouseInfo.RightMousedPressed)
                {
                    board.TryMoveUnit(SelectedUnit, HighlightedTile.BoardX, HighlightedTile.BoardY);
                }
            }

            //DEBUG
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                return new TargetingPlayerState(SelectedUnit.Abilities[0], SelectedUnit);
            }

            return this;
        }

        /// <summary>
        /// Draws the state.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(Textures.UnitSelect, new Vector2(SelectedUnit.CanvasX, SelectedUnit.CanvasY), Color.White);

            if (path != null)
            {
                foreach (Tile tile in path)
                {
                    spriteBatch.Draw(Textures.RedTileFilter, new Vector2(tile.CanvasX, tile.CanvasY), Color.White);
                }
            }
        }

        #endregion
    }
}
