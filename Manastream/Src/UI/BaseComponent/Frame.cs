namespace Manastream.Src.UI.BaseComponent
{
    #region Usings

    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The frame class that represents a simple rectangular frame.
    /// </summary>
    public class Frame : BaseComponent
    {
        #region Fields

        private Texture2D texture;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Frame"/> class.
        /// </summary>
        public Frame(int width, int height, IPositionProfile positionProfile, Color colour)
            : base(positionProfile)
        {
            this.Width = width;
            this.Height = height;
            this.Colour = colour;
        }

        #endregion

        #region Properties

        public Color Colour
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the frame.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, GetCoordinates(), Color.White);
        }

        /// <summary>
        /// Initialises the frame.
        /// </summary>
        public override void Initialise(Rectangle parent)
        {
            InitialiseCoordinates(parent);
            texture = BuildTexture(Color.Red);
        }

        /// <summary>
        /// Builds the texture in a specified colour.
        /// </summary>
        private Texture2D BuildTexture(Color colour)
        {
            Texture2D result = new Texture2D(Resources.GraphicsDevice, Width, Height);

            Color[] data = new Color[Width * Height];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                data[pixel] = colour;
            }

            result.SetData(data);

            return result;
        }

        #endregion
    }
}
