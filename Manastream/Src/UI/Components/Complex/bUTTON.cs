namespace Manastream.Src.UI.Components.Complex
{
    using Manastream.Src.EventSystem.Events;
    #region Usings

    using Manastream.Src.UI.Components.Basic;
    using Manastream.Src.UI.Enums;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    #endregion

    /// <summary>
    /// The button component.
    /// </summary>
    public class Button : ComplexUIComponent
    {
        #region Fields

        private Frame frame, defaultFrame, hoverFrame;
        private readonly string text;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Button"/> class.
        /// </summary>
        public Button(
            int width,
            int height,
            string text,
            IPositionProfile positionProfile,
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

        #region Properties

        public Event OnClickEvent
        {
            get;
            set;
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
            InitialiseComponents();
        }

        /// <summary>
        /// On hover handler.
        /// </summary>
        protected override void OnHover()
        {
            frame = hoverFrame;
        }

        /// <summary>
        /// On hover leave handler.
        /// </summary>
        protected override void OnHoverLeave()
        {
            frame = defaultFrame;
        }

        /// <summary>
        /// On click handler.
        /// </summary>
        protected override void OnClick()
        {
            eventManager.Notify(OnClickEvent);
        }

        /// <summary>
        /// Builds the components.
        /// </summary>
        private void BuildComponents(Color defaultBackgroundColour, Color defaultTextColour, Color hoverBackgroundColour, Color hoverTextColour)
        {
            FontGraphics defaultFontGraphics = new FontGraphics(text, Width, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), TextFormat.Shrink, defaultTextColour, Resources.Textures.Debug);
            defaultFrame = new Frame(Width, Height, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), defaultBackgroundColour);
            defaultFrame.Components.Add(defaultFontGraphics);

            FontGraphics hoverFontGraphics = new FontGraphics(text, Width, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), TextFormat.Shrink, hoverTextColour, Resources.Textures.Debug);
            hoverFrame = new Frame(Width, Height, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), hoverBackgroundColour);
            hoverFrame.Components.Add(hoverFontGraphics);

            frame = defaultFrame;
        }

        /// <summary>
        /// Initialises the components.
        /// </summary>
        private void InitialiseComponents()
        {
            defaultFrame.Initialise(GetBounds());
            hoverFrame.Initialise(GetBounds());
        }

        #endregion
    }
}
