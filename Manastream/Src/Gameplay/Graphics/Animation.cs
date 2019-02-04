namespace Manastream.Src.Gameplay.Graphics
{
    using Manastream.Src.GameResources;
    #region Usings

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The animation class that holds the logic for updating and displaying a spritesheet.
    /// </summary>
    public class Animation
    {
        #region Fields

        private Texture2D spritesheet;
        private int frames, frameIndex, frameDuration, currentAnimationTime, animationDuration, spriteWidth, spriteHeight;
        private Rectangle spriteSourceRectangle;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Animation"/> class.
        /// </summary>
        public Animation(int spriteWidth, int spriteHeight, int frameDuration, int frames, Texture2D spritesheet)
        {
            this.frameDuration = frameDuration;
            this.frames = frames;
            this.spritesheet = spritesheet;
            this.currentAnimationTime = 0;
            this.frameIndex = 0;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            this.animationDuration = frames * frameDuration;
            this.spriteSourceRectangle = new Rectangle(frameIndex * spriteWidth, 0, spriteWidth, spriteHeight);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the sprite that is to be displayed.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            //No need to update if there is only 1 frame
            if (frames == 1)
            {
                return;
            }

            currentAnimationTime += gameTime.ElapsedGameTime.Milliseconds;

            if (currentAnimationTime >= animationDuration)
            {
                currentAnimationTime = currentAnimationTime % animationDuration;
            }

            frameIndex = currentAnimationTime / frameDuration;

            spriteSourceRectangle = new Rectangle(frameIndex * spriteWidth, 0, spriteWidth, spriteHeight);
        }

        /// <summary>
        /// A helper method for returning an animation with a single frame.
        /// </summary>
        public static Animation SingleFrameAnimation(int width, int height, Texture2D texture)
        {
            return new Animation(width, height, 0, 1, texture);
        }

        /// <summary>
        /// Gets the current sprite.
        /// </summary>
        /// <returns></returns>
        public Texture2D GetCurrentAnimationFrame()
        {
            Color[] imageData = new Color[spriteWidth * spriteHeight];
            spritesheet.GetData(0, spriteSourceRectangle, imageData, 0, imageData.Length);

            Texture2D result = new Texture2D(Resources.GetInstance().GraphicsDevice, spriteWidth, spriteHeight);
            result.SetData(imageData);

            return result;
        }

        #endregion
    }
}
