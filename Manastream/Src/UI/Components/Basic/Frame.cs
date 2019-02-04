namespace Manastream.Src.UI.Components.Basic
{
    #region Usings

    using Manastream.Src.EventSystem.Events.Graphics;
    using Manastream.Src.Gameplay.Enums;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The frame class that represents a simple rectangular frame.
    /// </summary>
    public class Frame : BasicUIComponent
    {
        #region Fields

        private Texture2D texture;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Frame"/> class.
        /// </summary>
        public Frame(int width, int height, IPositionProfile positionProfile, DrawLayer drawLayer, Color colour)
            : base(positionProfile, drawLayer)
        {
            this.Width = width;
            this.Height = height;
            this.Colour = colour;
            this.Components = new List<BasicUIComponent>();
        }

        #endregion

        #region Properties

        public Color Colour
        {
            get;
        }

        public List<BasicUIComponent> Components
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the UI component.
        /// </summary>
        public override void Update(Rectangle parent)
        {
            SetCoordinates(parent);

            foreach (BasicUIComponent component in Components)
            {
                component.Update(GetBounds());
            }
        }

        /// <summary>
        /// Draws the UI component.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            eventManager.Notify(new TextureDrawReadyEvent(texture, GetCoordinates(), DrawLayer));

            foreach (BasicUIComponent component in Components)
            {
                component.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Initialises the UI component.
        /// </summary>
        public override void Initialise(Rectangle parent)
        {
            SetCoordinates(parent);
            texture = BuildTexture(Colour);

            foreach (BasicUIComponent component in Components)
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
