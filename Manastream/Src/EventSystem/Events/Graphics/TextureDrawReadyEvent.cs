namespace Manastream.Src.EventSystem.Events.Graphics
{
    #region Usings

    using Manastream.Src.Gameplay.Enums;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    public class TextureDrawReadyEvent : Event
    {
        public TextureDrawReadyEvent(Texture2D texture, Vector2 position, DrawLayer drawLayer)
            : base(EventTypes.Graphics.TextureDrawReady)
        {
            this.Texture = texture;
            this.Position = position;
            this.SourceRectangle = Rectangle.Empty;
            this.DrawLayer = drawLayer;
        }
        public TextureDrawReadyEvent(Texture2D texture, Vector2 position, Rectangle sourceRectangle, DrawLayer drawLayer)
            : base(EventTypes.Graphics.TextureDrawReady)
        {
            this.Texture = texture;
            this.Position = position;
            this.SourceRectangle = sourceRectangle;
            this.DrawLayer = drawLayer;
        }

        public Texture2D Texture
        {
            get;
        }

        public Vector2 Position
        {
            get;
        }

        public Rectangle SourceRectangle
        {
            get;
        }

        public DrawLayer DrawLayer
        {
            get;
        }
    }
}
