namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities.Templates;
    using Manastream.Src.Gameplay.Entities;
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.Gameplay.Services;
    using Manastream.Src.Utility;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The unselected player state class that represents the interactions when no unit is selected.
    /// </summary>
    public class UnselectedPlayerState : PlayerState
    {
        #region Fields

        private Template template; //DEBUG
        private List<Tile> tiles;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="UnselectedPlayerState"/> class.
        /// </summary>
        public UnselectedPlayerState()
            : base(null)
        {
            this.template = new SingleTargetTemplate();
            this.tiles = new List<Tile>();
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
                if (HighlightedUnit != null)
                {
                    return new SelectedPlayerState(HighlightedUnit);
                }
            }

            tiles = new List<Tile>();

            if (HighlightedTile != null)
            {
                Point[] tileCoords = TemplateService.GetTilesFromTemplate(new Point(HighlightedTile.BoardX, HighlightedTile.BoardY), template);
                
                foreach (Point tileCoord in tileCoords)
                {
                    Tile tile = board.GetTile(tileCoord.X, tileCoord.Y);
                    if (tile != null)
                    {
                        tiles.Add(tile);
                    }
                }
            }

            return this;
        }

        /// <summary>
        /// Draws the state.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            //DEBUG
            if (tiles.Count > 0)
            {
                foreach (Tile tile in tiles)
                {
                    int x = tile.CanvasX + (Tile.Diameter / 2) - (Unit.Diameter / 2);
                    int y = tile.CanvasY + (Tile.Diameter / 2) - (Unit.Diameter / 2);

                    spriteBatch.Draw(Textures.RedUnit, new Vector2(x, y), Color.White);
                }
            }
        }

        #endregion
    }
}
