namespace Manastream.Src.UI.Components.Basic
{
    #region Usings

    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The frame class that represents a simple rectangular frame.
    /// </summary>
    public class Frame : UIComponent
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
            this.Components = new List<UIComponent>();
        }

        #endregion

        #region Properties

        public Color Colour
        {
            get;
        }

        public List<UIComponent> Components
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the UI component.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, GetCoordinates(), Color.White);

            foreach (UIComponent component in Components)
            {
                component.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Initialises the UI component.
        /// </summary>
        public override void Initialise(Rectangle parent)
        {
            InitialiseCoordinates(parent);
            texture = BuildTexture(Colour);

            foreach (UIComponent component in Components)
            {
                component.Initialise(GetBounds());
            }
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
