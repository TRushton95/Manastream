namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
{
    using Manastream.Src.Gameplay.Abilities;
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
        public TargetingPlayerState(Ability selectedAbility, Unit selectedUnit)
            : base(selectedUnit)
        {
            this.SelectedAbility = selectedAbility;
            this.templateAffectedTiles = new List<Tile>();
        }

        #endregion

        #region Properties

        //DEBUG - Change this to selected ability once created, and take template from there
        public Ability SelectedAbility
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
                List<Point> tileCoords = TemplateService.GetAffectedTileCoordinates(new Point(HighlightedTile.BoardX, HighlightedTile.BoardY), SelectedAbility.Template);
                templateAffectedTiles = board.GetTiles(tileCoords);
            }

            if (MouseInfo.LeftMousePressed)
            {
                SelectedAbility.TryExecute(HighlightedTile, templateAffectedTiles, SelectedUnit);
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
                    spriteBatch.Draw(Textures.RedTileFilter, new Vector2(tile.CanvasX, tile.CanvasY), Color.White);
                }
            }
        }

        #endregion
    }
}
