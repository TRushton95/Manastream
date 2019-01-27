namespace Manastream.Src.UI.Components.Complex
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.GameResources;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The complex ui component class that represents a usable component, built out of base UI components.
    /// </summary>
    public abstract class ComplexUIComponent : Listener
    {
        #region Fields

        protected int posX, posY;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ComplexUIComponent"/> class.
        /// </summary>
        public ComplexUIComponent(int width, int height, IPositionProfile positionProfile)
        {
            this.Width = width;
            this.Height = height;
            this.PositionProfile = positionProfile;
        }

        #endregion

        #region Properties

        public int Width
        {
            get;
            protected set;
        }

        public int Height
        {
            get;
            protected set;
        }

        public IPositionProfile PositionProfile
        {
            get;
        }

        public bool Hovered
        {
            get;
            private set;
        }

        protected Resources Resources => Resources.GetInstance();

        #endregion

        #region Methods

        /// <summary>
        /// Gets a lsit of the descendant components.
        /// </summary>
        public virtual List<ComplexUIComponent> GetDescendants()
        {
            return new List<ComplexUIComponent>() { this };
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
        public abstract void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Initialises the UI component.
        /// </summary>
        public abstract void Initialise(Rectangle parent);

        /// <summary>
        /// Gets the boundaries of the component.
        /// </summary>
        public Rectangle GetBounds()
        {
            return new Rectangle(posX, posY, Width, Height);
        }

        /// <summary>
        /// Gets the coordinates of the component.
        /// </summary>
        public Vector2 GetCoordinates()
        {
            return new Vector2(posX, posY);
        }

        /// <summary>
        /// Initialises the coordinates of the UI component based on its parent's location
        /// </summary>
        protected void InitialiseCoordinates(Rectangle parent)
        {
            Vector2 coords = PositionProfile.GetPosition(GetBounds(), parent);

            posX = (int)coords.X;
            posY = (int)coords.Y;
        }

        #endregion
    }
}
