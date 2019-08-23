namespace Manastream.Src.EventSystem.Events.Graphics
{
    #region Usings
    
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Shared.Enums;

    #endregion

    public class TextureDrawReadyEvent : Event
    {
        public TextureDrawReadyEvent(Texture2D texture, Vector2 position, DrawLayer drawLayer)
            : base(EventTypes.Graphics.TextureDrawReady)
        {
            this.Texture = texture;
            this.Position = position;
            this.SourceRectangle = null;
            this.Rotation = 0;
            this.RotationOrigin = Vector2.Zero;
            this.DrawLayer = drawLayer;
        }

        public TextureDrawReadyEvent(Texture2D texture, Vector2 position, Rectangle sourceRectangle, DrawLayer drawLayer)
            : base(EventTypes.Graphics.TextureDrawReady)
        {
            this.Texture = texture;
            this.Position = position;
            this.SourceRectangle = sourceRectangle;
            this.Rotation = 0;
            this.RotationOrigin = Vector2.Zero;
            this.DrawLayer = drawLayer;
        }

        public TextureDrawReadyEvent(Texture2D texture, Vector2 position, float rotation, Vector2 rotationOrigin, DrawLayer drawLayer)
            : base(EventTypes.Graphics.TextureDrawReady)
        {
            this.Texture = texture;
            this.Position = position;
            this.SourceRectangle = null;
            this.Rotation = rotation;
            this.RotationOrigin = rotationOrigin;
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

        public Rectangle? SourceRectangle
        {
            get;
        }

        public float Rotation
        {
            get;
        }

        public Vector2 RotationOrigin
        {
            get;
        }

        public DrawLayer DrawLayer
        {
            get;
        }
    }
}
