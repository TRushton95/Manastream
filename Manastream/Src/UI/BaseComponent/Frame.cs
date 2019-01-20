namespace Manastream.Src.UI.BaseComponent
{
    #region Usings

    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class Frame : BaseComponent
    {
        #region Fields

        private Texture2D texture;

        #endregion

        #region Constructors

        public Frame(int width, int height, IPositionProfile positionProfile, Color colour)
            : base(width, height, positionProfile)
        {
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, GetCoordinates(), Color.White);
        }

        public override void Initialise(Rectangle parent)
        {
            base.Initialise(parent);

            texture = BuildTexture(Color.Red);
        }

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
