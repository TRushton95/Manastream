namespace Manastream.Src.Gameplay.Entities.Actor
{
    #region Usings

    using Manastream.Src.DataStructures;
    using Manastream.Src.EventSystem;
    using Manastream.Src.EventSystem.Events.Graphics;
    using Manastream.Src.Gameplay.Enums;
    using Manastream.Src.Gameplay.Graphics;
    using Manastream.Src.GameResources;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The game actor base class representing any entity that exists on the <see cref="Board"/>.
    /// </summary>
    public abstract class GameActor : Listener
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="GameActor"/> class.
        /// </summary>
        public GameActor(int boardX, int boardY, int canvasX, int canvasY)
        {
            this.BoardPosition = new Position(boardX, boardY);
            this.CanvasPosition = new Position(canvasX, canvasY);
            this.Animations = new Dictionary<int, Animation>();
            this.AnimationIndex = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The position of the game actor on the board.
        /// </summary>
        public Position BoardPosition
        {
            get;
            set;
        }

        /// <summary>
        /// The position of the texture on the canvas.
        /// </summary>
        public Position CanvasPosition
        {
            get;
            set;
        }

        public Dictionary<int, Animation> Animations
        {
            get;
            protected set;
        }

        protected int AnimationIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the global instance of the <see cref="Textures"/> class.
        /// </summary>
        protected static Textures Textures => Resources.GetInstance().Textures;

        #endregion

        #region Methods

        /// <summary>
        /// Updates the game actor.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            Animation animation;
            Animations.TryGetValue(AnimationIndex, out animation);

            if (animation != null)
            {
                animation.Update(gameTime);
            }
        }

        /// <summary>
        /// Renders the game actor.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            Animation animation;
            Animations.TryGetValue(AnimationIndex, out animation);

            if (animation == null)
            {
                return;
            }

            Texture2D texture = animation.GetCurrentAnimationFrame();

            if (texture != null)
            {
                eventManager.Notify(new TextureDrawReadyEvent(texture, CanvasPosition.ToVector2(), DrawLayer.Game));
            }
        }

        #endregion
    }
}
