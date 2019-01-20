namespace Manastream.Src.UI.BaseComponent
{
    #region Usings

    using Manastream.Src.GameResources;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The base component class that represents a UI component.
    /// </summary>
    public abstract class BaseComponent
    {
        #region Fields

        protected int posX, posY;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="BaseComponent"/> class.
        /// </summary>
        public BaseComponent(int width, int height, IPositionProfile positionProfile)
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
        }

        public int Height
        {
            get;
        }

        public IPositionProfile PositionProfile
        {
            get;
        }

        protected Resources Resources => Resources.GetInstance();

        #endregion

        #region Methods

        /// <summary>
        /// Draws the UI component.
        /// </summary>
        public abstract void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Initialises the UI component.
        /// </summary>
        public virtual void Initialise(Rectangle parent)
        {
            InitialiseCoordinates(parent);
        }

        /// <summary>
        /// Gets the boundaries of the component.
        /// </summary>
        protected Rectangle GetBounds()
        {
            return new Rectangle(posX, posY, Width, Height);
        }

        /// <summary>
        /// Gets the coordinates of the component.
        /// </summary>
        protected Vector2 GetCoordinates()
        {
            return new Vector2(posX, posY);
        }

        /// <summary>
        /// Initialises the coordinates of the UI component based on its parent's location
        /// </summary>
        private void InitialiseCoordinates(Rectangle parent)
        {
            Vector2 coords = PositionProfile.GetPosition(GetBounds(), parent);

            posX = (int)coords.X;
            posY = (int)coords.Y;
        }

        #endregion
    }
}
