namespace Manastream.Src.UI.Components.Complex
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.Gameplay.Enums;
    using Manastream.Src.GameResources;
    using Manastream.Src.UI.Components.Basic;
    using Manastream.Src.UI.JsonConverters;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The complex ui component class that represents a usable component, built out of base UI components.
    /// </summary>
    public abstract class UIComponent : BasicUIComponent
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="UIComponent"/> class.
        /// </summary>
        public UIComponent(int id, int width, int height, IPositionProfile positionProfile, DrawLayer drawLayer)
            : base(positionProfile, drawLayer)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.Visible = true;
        }

        #endregion

        #region Properties

        public int Id
        {
            get;
        }

        public bool Visible
        {
            get;
            private set;
        }

        public bool Hovered
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a lsit of the descendant components.
        /// </summary>
        public virtual List<UIComponent> GetDescendants()
        {
            return new List<UIComponent>() { this };
        }

        public void Show()
        {
            Visible = true;
        }

        public void Hide()
        {
            Visible = false;
        }

        /// <summary>
        /// Sets the component to hovered and executes the on hover handler.
        /// </summary>
        public void Hover()
        {
            Hovered = true;
            OnHover();
        }

        /// <summary>
        /// Sets the component to not hovered and executes the on hover leave handler.
        /// </summary>
        public void HoverLeave()
        {
            Hovered = false;
            OnHoverLeave();
        }

        /// <summary>
        /// Executes the on click handler.
        /// </summary>
        public void Click()
        {
            OnClick();
        }

        /// <summary>
        /// On hover handler.
        /// </summary>
        protected virtual void OnHover() { }

        /// <summary>
        /// On hover leave handler.
        /// </summary>
        protected virtual void OnHoverLeave() { }

        /// <summary>
        /// On click handler.
        /// </summary>
        protected virtual void OnClick() { }

        /// <summary>
        /// Draws the UI component.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                DrawDetail(spriteBatch);
            }
        }

        /// <summary>
        /// Defines the implementation details of the Draw method.
        /// </summary>
        protected abstract void DrawDetail(SpriteBatch spriteBatch);

        /// <summary>
        /// Updates the coordinates of the UI component and it's composite components.
        /// </summary>
        protected abstract void UpdateCoordinates(Rectangle parent);

        #endregion
    }
}
