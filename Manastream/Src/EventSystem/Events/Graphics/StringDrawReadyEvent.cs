namespace Manastream.Src.EventSystem.Events.Graphics
{
    #region Usings

    using Manastream.Src.Gameplay.Enums;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class StringDrawReadyEvent : Event
    {
        public StringDrawReadyEvent(string text, SpriteFont font, Vector2 position, float scale, Color colour, DrawLayer drawLayer)
            : base(EventTypes.Graphics.StringDrawReady)
        {
            this.Text = text;
            this.Font = font;
            this.Position = position;
            this.Scale = scale;
            this.Colour = colour;
            this.DrawLayer = drawLayer;
        }

        public string Text
        {
            get;
        }

        public SpriteFont Font
        {
            get;
        }

        public Vector2 Position
        {
            get;
        }

        public float Scale
        {
            get;
        }

        public Color Colour
        {
            get;
        }

        public DrawLayer DrawLayer
        {
            get;
        }
    }
}
