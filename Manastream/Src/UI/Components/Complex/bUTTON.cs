namespace Manastream.Src.UI.Components.Complex
{
    #region Usings

    using System.Collections.Generic;
    using Manastream.Src.UI.Components.Basic;
    using Manastream.Src.UI.Enums;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The button component.
    /// </summary>
    public class Button : ComplexUIComponent
    {
        #region Fields

        private Frame frame;
        private readonly string text;

        #endregion

        #region Constructors

        public Button(
            int width,
            int height,
            string text,
            IPositionProfile positionProfile,
            int priority)
            : base(width, height, positionProfile)
        {
            this.text = text;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the UI component.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);
        }

        /// <summary>
        /// Initialises the UI component.
        /// </summary>
        public override void Initialise(Rectangle parent)
        {
            InitialiseCoordinates(parent);
            BuildComponents();
        }

        /// <summary>
        /// Builds and initialises the consituent UI components.
        /// </summary>
        private void BuildComponents()
        {
            FontGraphics fontGraphics = new FontGraphics(text, Width, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), TextFormat.Shrink, Resources.Textures.Debug);
            frame = new Frame(Width, Height, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), Color.White);
            frame.Components.Add(fontGraphics);

            frame.Initialise(GetBounds());
        }

        #endregion
    }
}
