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
            path = null;

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
            
            if (HighlightedTile != null)
            {
                path = board.GetPath(SelectedUnit, HighlightedTile);
                path.RemoveAt(0); // TO-DO Do we ever need the origin tile? Could remove from method if not.

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

            if (path != null && path.Count > 0)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    spriteBatch.Draw(Textures.MoveArrow, new Vector2(path[i].CanvasX, path[i].CanvasY), Color.White);
                }

                spriteBatch.Draw(Textures.GreenTileFilter, new Vector2(path[path.Count - 1].CanvasX, path[path.Count - 1].CanvasY), Color.White);
            }
        }

        #endregion
    }
}
