namespace Manastream.Src.UI.BaseComponent
{
    #region Usings

    using Manastream.Src.GameResources;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public abstract class BaseComponent
    {
        #region Fields

        protected int posX, posY;

        #endregion

        #region Constructors

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

        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual void Initialise(Rectangle parent)
        {
            InitialiseCoordinates(parent);
        }

        protected Rectangle GetBounds()
        {
            return new Rectangle(posX, posY, Width, Height);
        }

        protected Vector2 GetCoordinates()
        {
            return new Vector2(posX, posY);
        }

        private void InitialiseCoordinates(Rectangle parent)
        {
            Vector2 coords = PositionProfile.GetPosition(GetBounds(), parent);

            posX = (int)coords.X;
            posY = (int)coords.Y;
        }

        #endregion
    }
}
