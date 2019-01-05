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
    /// The targeting player state class that represents the interactions when a unit and an ability is selected.
    /// </summary>
    public class TargetingPlayerState : PlayerState
    {
        #region Fields

        private List<Tile> templateAffectedTiles;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="TargetingPlayerState"/> class.
        /// </summary>
        public TargetingPlayerState(Template selectedTemplate, Unit selectedUnit)
            : base(selectedUnit)
        {
            this.SelectedTemplate = selectedTemplate;
            this.templateAffectedTiles = new List<Tile>();
        }

        #endregion

        #region Properties

        //DEBUG - Change this to selected ability once created, and take template from there
        public Template SelectedTemplate
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes user input.
        /// </summary>
        public override PlayerState ProcessInput(Board board, Point mouse)
        {
            base.ProcessInput(board, mouse);

            if (MouseInfo.RightMousedPressed)
            {
                return new SelectedPlayerState(SelectedUnit);
            }

            templateAffectedTiles = new List<Tile>();

            if (HighlightedTile != null)
            {
                Point[] tileCoords = TemplateService.GetAffectedTileCoordinates(new Point(HighlightedTile.BoardX, HighlightedTile.BoardY), SelectedTemplate);

                foreach (Point tileCoord in tileCoords)
                {
                    Tile tile = board.GetTile(tileCoord.X, tileCoord.Y);
                    if (tile != null)
                    {
                        templateAffectedTiles.Add(tile);
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

            spriteBatch.Draw(Textures.UnitSelect, new Vector2(SelectedUnit.CanvasX, SelectedUnit.CanvasY), Color.White);

            if (templateAffectedTiles.Count > 0)
            {
                foreach (Tile tile in templateAffectedTiles)
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
