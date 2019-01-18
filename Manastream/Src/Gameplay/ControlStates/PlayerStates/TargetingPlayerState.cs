namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
{
    #region Usings

    using Manastream.Src.EventSystem.Events.Debug;
    using Manastream.Src.Gameplay.Abilities;
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
    /// The targeting player state class that represents the player interactions when a unit and an ability is selected.
    /// </summary>
    public class TargetingPlayerState : PlayerState
    {
        #region Fields

        private bool validCast;
        private List<Tile> templateAffectedTiles, abilityPath;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="TargetingPlayerState"/> class.
        /// </summary>
        public TargetingPlayerState(Player player, Unit selectedUnit, Ability selectedAbility)
            : base(player, selectedUnit)
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
            PlayerState result = base.ProcessInput(board, mouse);

            if (result != null)
            {
                return result;
            }

            abilityPath = null;
            templateAffectedTiles = new List<Tile>();
            validCast = false;

            if (MouseInfo.RightMousePressed)
            {
                return new SelectedPlayerState(player, SelectedUnit);
            }

            if (HighlightedTile != null)
            {
                abilityPath = board.GetAbilityPath(SelectedUnit, HighlightedTile);

                List<Point> tileCoords = TemplateService.GetAffectedTileCoordinates(new Point(HighlightedTile.BoardX, HighlightedTile.BoardY), SelectedAbility.Template);
                templateAffectedTiles = board.GetTiles(tileCoords);
            }

            validCast = ValidateCastConditions();

            if (MouseInfo.LeftMousePressed)
            {
                if (validCast)
                {
                    SelectedAbility.Execute(HighlightedTile, templateAffectedTiles, SelectedUnit);
                }
                else
                {
                    eventManager.Notify(new UserAlertEvent("You cannot cast that there!"));
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

            Texture2D filter = validCast ? Textures.GreenTileFilter : Textures.RedTileFilter;

            if (templateAffectedTiles.Count > 0)
            {
                foreach (Tile tile in templateAffectedTiles)
                {
                    spriteBatch.Draw(filter, new Vector2(tile.CanvasX, tile.CanvasY), Color.White);
                }
            }
        }

        /// <summary>
        /// Returns a value indicating whether the ability meets the conditions to be cast.
        /// </summary>
        private bool ValidateCastConditions()
        {
            bool isInRange = abilityPath.Count <= SelectedAbility.Range;
            bool isValidTarget = TargetValidationService.Validate(HighlightedTile, SelectedAbility.TargetType, SelectedUnit);

            return isInRange && isValidTarget;
        }

        #endregion
    }
}
