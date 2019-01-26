namespace Manastream.Src.UI.Components.Complex
{
    #region Usings

    using Manastream.Src.UI.Components.Basic;
    using Manastream.Src.UI.Enums;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class Button : ComplexUIComponent
    {
        private Frame frame;
        private readonly string text;

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);
        }

        public override void Initialise(Rectangle parent)
        {
            InitialiseCoordinates(parent);
            BuildComponents();
        }

        private void BuildComponents()
        {
            FontGraphics fontGraphics = new FontGraphics(text, Width, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), TextFormat.Shrink, Resources.Textures.Debug);
            frame = new Frame(Width, Height, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), Color.White);
            frame.Components.Add(fontGraphics);
            frame.Initialise(GetBounds());
        }
    }
}
