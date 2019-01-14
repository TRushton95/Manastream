namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
{
    using Manastream.Src.EventSystem.Events.Debug;
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
        public SelectedPlayerState(Player player, Unit selectedUnit)
            : base(player, selectedUnit)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes user input.
        /// </summary>
        public override PlayerState ProcessInput(Board board, Point mouse)
        {
            PlayerState result = base.ProcessInput(board, mouse);

            if (result != null)
            {
                return result;
            }

            path = null;

            if (MouseInfo.RightMousePressed)
            {
                if (HighlightedTile?.Occupant == null)
                {
                    return new UnselectedPlayerState(player);
                }

                if (HighlightedTile?.Occupant != SelectedUnit && HighlightedTile.Occupant.Owner.Team == player.Team)
                {
                    return new SelectedPlayerState(player, HighlightedTile.Occupant);
                }
            }
            
            if (HighlightedTile != null)
            {
                path = board.GetUnitPath(SelectedUnit, HighlightedTile);

                if (MouseInfo.LeftMousePressed)
                {
                    //TO-DO Should this attempt to move to all out of range paths?
                    foreach (Tile pathSegment in path)
                    {
                        board.TryMoveUnit(SelectedUnit, pathSegment.BoardX, pathSegment.BoardY);
                    }
                }
            }

            //DEBUG
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                return new TargetingPlayerState(player, SelectedUnit, SelectedUnit.Abilities[0]);
            }

            return this;
        }

        /// <summary>
        /// Logic to do when entering the selected player state.
        /// </summary>
        public override void OnEnter()
        {
            eventManager.Notify(new SelectUnitEvent(SelectedUnit));
        }

        /// <summary>
        /// Logic to do when entering the selected player state.
        /// </summary>
        public override void OnLeave()
        {
            eventManager.Notify(new SelectUnitEvent(null));
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

                int totalCost = 0;
                foreach (Tile tile in path)
                {
                    totalCost += tile.MovementCost;
                    Texture2D filter = totalCost > SelectedUnit.CurrentEnergy ? Textures.RedTileFilter : Textures.GreenTileFilter;

                    spriteBatch.Draw(filter, tile.CanvasPosition, Color.White);
                }
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
