namespace Manastream.Src.UI.Components.Complex
{
    #region Usings
    
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

        private Frame defaultFrame, hoverFrame;
        private readonly string text;

        #endregion

        #region Constructors

        public Button(
            int width,
            int height,
            string text,
            IPositionProfile positionProfile,
            int priority,
            Color defaultBackgroundColour,
            Color defaultTextColour,
            Color hoverBackgroundColour,
            Color hoverTextColour)
            : base(width, height, positionProfile)
        {
            this.text = text;
            BuildComponents(defaultBackgroundColour, defaultTextColour, hoverBackgroundColour, hoverTextColour);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the UI component.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Hovered)
            {
                hoverFrame.Draw(spriteBatch);
            }
            else
            {
                defaultFrame.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Initialises the UI component.
        /// </summary>
        public override void Initialise(Rectangle parent)
        {
            InitialiseCoordinates(parent);
            InitialiseComponents();
        }

        /// <summary>
        /// Builds and initialises the consituent UI components.
        /// </summary>
        private void BuildComponents(Color defaultBackgroundColour, Color defaultTextColour, Color hoverBackgroundColour, Color hoverTextColour)
        {
            FontGraphics defaultFontGraphics = new FontGraphics(text, Width, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), TextFormat.Shrink, defaultTextColour, Resources.Textures.Debug);
            defaultFrame = new Frame(Width, Height, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), defaultBackgroundColour);
            defaultFrame.Components.Add(defaultFontGraphics);

            FontGraphics hoverFontGraphics = new FontGraphics(text, Width, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), TextFormat.Shrink, hoverTextColour, Resources.Textures.Debug);
            hoverFrame = new Frame(Width, Height, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), hoverBackgroundColour);
            hoverFrame.Components.Add(hoverFontGraphics);
        }

        private void InitialiseComponents()
        {
            defaultFrame.Initialise(GetBounds());
            hoverFrame.Initialise(GetBounds());
        }

        #endregion
    }
}
