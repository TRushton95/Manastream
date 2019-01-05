﻿namespace Manastream.Src.Gameplay.ControlStates
{
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
    /// The control state interface that defines a contract of how the player must interact with the board
    /// </summary>
    public abstract class ControlState
    {
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

        protected Textures Textures => Resources.GetInstance().Textures;

        #endregion

        #region Methods

        /// <summary>
        /// Processes user input.
        /// </summary>
        public virtual PlayerState ProcessInput(Board board, Point mouse)
        {
            HighlightedTile = board.GetTileAtCanvasPosition(mouse.X, mouse.Y);

            if (HighlightedTile != null)
            {
                HighlightedUnit = HighlightedTile.Occupant;
            }

            return null;
        }
        
        /// <summary>
        /// Draws the state.
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (HighlightedTile != null)
            {
                spriteBatch.Draw(Textures.TileHighlight, new Vector2(HighlightedTile.CanvasX, HighlightedTile.CanvasY), Color.White);
            }

            if (HighlightedUnit != null)
            {
                spriteBatch.Draw(Textures.UnitHighlight, new Vector2(HighlightedUnit.CanvasX, HighlightedUnit.CanvasY), Color.White);
            }
        }

        #endregion
    }
}