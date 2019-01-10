﻿namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
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
    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The unselected player state class that represents the player interactions when a unit is selected.
    /// </summary>
    public class SelectedPlayerState : PlayerState
    {
        #region Fields
        
        private List<Tile> path;
        private readonly Vector2 rotationOrigin = new Vector2(Tile.Diameter / 2, Tile.Diameter / 2);

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

            if (path != null && path.Count > 0)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    float rotation = GetArrowRotation(path[i + 1], path[i]);
                    spriteBatch.Draw(Textures.MoveArrow, path[i].CanvasPosition + rotationOrigin, null, Color.White, rotation, rotationOrigin, 1, SpriteEffects.None, 1);
                }

                Vector2 pathEnd = path[path.Count - 1].CanvasPosition;
                spriteBatch.Draw(Textures.GreenTileFilter, pathEnd, Color.White);
            }
        }

        /// <summary>
        /// Calculates the rotation for a movement arrow to point to another tile.
        /// </summary>
        private float GetArrowRotation(Tile currentTile, Tile nextTile)
        {
            if (currentTile == null && nextTile == null)
            {
                return float.NaN;
            }

            float result = 0;
            
            Vector2 direction = currentTile.CanvasPosition - nextTile.CanvasPosition;
            direction.Normalize();
            result = (float)Math.Atan2(direction.Y, direction.X);

            return result;
        }

        #endregion
    }
}
