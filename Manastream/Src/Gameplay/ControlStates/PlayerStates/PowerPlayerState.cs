namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
{
    #region Usings

    using Manastream.Src.Gameplay.Abilities;
    using Manastream.Src.Gameplay.Entities;
    using Manastream.Src.Gameplay.Entities.Actors.Tiles;
    using Manastream.Src.Gameplay.Services;
    using Manastream.Src.Utility;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The power player state that represents the interactions when a player has selected a power.
    /// </summary>
    public class PowerPlayerState : PlayerState
    {
        #region Fields

        private bool validCast;
        private List<Tile> templateAffectedTiles;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PowerPlayerState"/> class.
        /// </summary>
        public PowerPlayerState(Player player, Ability selectedAbility)
            : base(player, null)
        {
            this.SelectedAbility = selectedAbility;
            this.templateAffectedTiles = new List<Tile>();
        }

        #endregion

        #region Properties

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
            
            templateAffectedTiles = new List<Tile>();
            validCast = false;

            if (MouseInfo.RightMousePressed)
            {
                return new UnselectedPlayerState(player);
            }

            if (HighlightedTile != null)
            {
                List<Point> tileCoords = TemplateService.GetAffectedTileCoordinates(new Point(HighlightedTile.BoardX, HighlightedTile.BoardY), SelectedAbility.Template);
                templateAffectedTiles = board.GetTiles(tileCoords);
            }

            validCast = TargetValidationService.Validate(HighlightedTile, SelectedAbility.TargetType, player.PowerCaster);

            if (MouseInfo.LeftMousePressed)
            {
                SelectedAbility.Execute(HighlightedTile, templateAffectedTiles, player.PowerCaster);
            }

            return this;
        }

        /// <summary>
        /// Draws the state.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            Texture2D filter = validCast ? Textures.GreenTileFilter : Textures.RedTileFilter;

            if (templateAffectedTiles.Count > 0)
            {
                foreach (Tile tile in templateAffectedTiles)
                {
                    spriteBatch.Draw(filter, new Vector2(tile.CanvasX, tile.CanvasY), Color.White);
                }
            }
        }

        #endregion
    }
}
