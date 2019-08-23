namespace Manastream.Src.UI.Components.Basic
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.GameResources;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Shared.Enums;

    #endregion

    /// <summary>
    /// The base component class that represents a UI component.
    /// </summary>
    public abstract class BasicUIComponent : Listener
    {
        #region Fields

        protected int posX, posY;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="BasicUIComponent"/> class.
        /// </summary>
        public BasicUIComponent(IPositionProfile positionProfile, DrawLayer drawLayer)
        {
            this.PositionProfile = positionProfile;
            this.DrawLayer = drawLayer;
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

        public DrawLayer DrawLayer
        {
            get;
        }

        protected Resources Resources => Resources.GetInstance();

        #endregion

        #region Methods

        /// <summary>
        /// Updates the UI component.
        /// </summary>
        public abstract void Update(Rectangle parent);

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
        /// Gets the coordinates of the UI component based on its parent's location
        /// </summary>
        protected void SetCoordinates(Rectangle parent)
        {
            Vector2 coords = PositionProfile.GetPosition(GetBounds(), parent);

            posX = (int)coords.X;
            posY = (int)coords.Y;
        }

        #endregion
    }
}
