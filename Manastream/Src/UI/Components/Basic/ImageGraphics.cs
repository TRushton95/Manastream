﻿namespace Manastream.Src.UI.Components.Basic
{
    #region Usings

    using Manastream.Src.EventSystem.Events.Graphics;
    using Manastream.Src.Gameplay.Enums;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The image graphics class that displays a texture.
    /// </summary>
    public class ImageGraphics : BasicUIComponent
    {
        #region Fields

        private readonly Texture2D image;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ImageGraphics"/> class.
        /// </summary>
        public ImageGraphics(Texture2D image, IPositionProfile positionProfile, DrawLayer drawLayer)
            : base(positionProfile, drawLayer)
        {
            this.image = image;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the text.
        /// </summary>
        public override void Update(Rectangle parent)
        {
            SetCoordinates(parent);
        }

        /// <summary>
        /// Draws the image.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            eventManager.Notify(new TextureDrawReadyEvent(image, GetCoordinates(), DrawLayer));
        }

        /// <summary>
        /// Draws the image graphics.
        /// </summary>
        public override void Initialise(Rectangle parent)
        {
            InitialiseDimensions();
            SetCoordinates(parent);
        }

        /// <summary>
        /// Initialise the dimensions of the image graphics.
        /// </summary>
        private void InitialiseDimensions()
        {
            Width = image.Width;
            Height = image.Height;
        }

        #endregion
    }
}
