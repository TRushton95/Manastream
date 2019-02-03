namespace Manastream.Src.Gameplay.ControlStates.PlayerStates
{
    using Manastream.Src.DataStructures;
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

        private bool validTarget;
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
            validTarget = false;

            if (MouseInfo.RightMousePressed)
            {
                return new SelectedPlayerState(player, SelectedUnit);
            }

            if (HighlightedTile != null)
            {
                abilityPath = board.GetAbilityPath(SelectedUnit, HighlightedTile);

                List<Position> tileCoords = TemplateService.GetAffectedTileCoordinates(HighlightedTile.BoardPosition, SelectedAbility.Template);
                templateAffectedTiles = board.GetTiles(tileCoords);
            }

            validTarget = IsValidTarget();

            if (MouseInfo.LeftMousePressed)
            {
                if (!IsValidTarget())
                {
                    eventManager.Notify(new UserAlertEvent("You cannot cast that there!"));
                }
                else if (!IsTargetInRange())
                {
                    eventManager.Notify(new UserAlertEvent("Target is not in range!"));
                }
                else
                {
                    SelectedAbility.Execute(HighlightedTile, templateAffectedTiles, SelectedUnit);
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

            Texture2D filter = validTarget ? Textures.GreenTileFilter : Textures.RedTileFilter;

            if (templateAffectedTiles.Count > 0)
            {
                foreach (Tile tile in templateAffectedTiles)
                {
                    spriteBatch.Draw(filter, tile.CanvasPosition.ToVector2(), Color.White);
                }
            }
        }

        /// <summary>
        /// Returns a value indicating whether the target is valid.
        /// </summary>
        private bool IsValidTarget()
        {
            return TargetValidationService.Validate(HighlightedTile, SelectedAbility.TargetType, SelectedUnit);
        }

        /// <summary>
        /// Returns a value indicating whether the target is in range.
        /// </summary>
        /// <returns></returns>
        private bool IsTargetInRange()
        {
            return abilityPath.Count <= SelectedAbility.Range;
        }

        #endregion
    }
}
