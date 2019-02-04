namespace Manastream.Src.Gameplay.Graphics
{
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

        private int frames, frameIndex, frameDuration, currentAnimationTime, animationDuration;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Animation"/> class.
        /// </summary>
        public Animation(int spriteWidth, int spriteHeight, int frameDuration, int frames, Texture2D spritesheet)
        {
            this.Spritesheet = spritesheet;
            this.SpriteSourceRectangle = new Rectangle(frameIndex * spriteWidth, 0, spriteWidth, spriteHeight);
            this.SpriteWidth = spriteWidth;
            this.SpriteHeight = spriteHeight;
            this.frameDuration = frameDuration;
            this.frames = frames;
            this.currentAnimationTime = 0;
            this.frameIndex = 0;
            this.animationDuration = frames * frameDuration;
        }

        #endregion

        #region Properties

        public Texture2D Spritesheet
        {
            get;
            private set;
        }

        public Rectangle SpriteSourceRectangle
        {
            get;
            private set;
        }

        public int SpriteWidth
        {
            get;
            private set;
        }

        public int SpriteHeight
        {
            get;
            private set;
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

            SpriteSourceRectangle = new Rectangle(frameIndex * SpriteWidth, 0, SpriteWidth, SpriteHeight);
        }

        /// <summary>
        /// A helper method for returning an animation with a single frame.
        /// </summary>
        public static Animation SingleFrameAnimation(int width, int height, Texture2D texture)
        {
            return new Animation(width, height, 0, 1, texture);
        }

        #endregion
    }
}
