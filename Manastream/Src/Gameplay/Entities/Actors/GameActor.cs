namespace Manastream.Src.Gameplay.Entities.Actor
{
    #region Usings

    using Manastream.Src.Resources;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The game actor base class representing any entity that exists on the <see cref="Board"/>.
    /// </summary>
    public abstract class GameActor
    {
        #region Fields

        protected readonly Textures textures = Resources.GetInstance().Textures;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="GameActor"/> class.
        /// </summary>
        public GameActor()
        {
            this.BoardX = 0;
            this.BoardY = 0;
            this.CanvasX = 0;
            this.CanvasY = 0;
            this.Sprite = null;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The x coordinate on the board.
        /// </summary>
        public int BoardX
        {
            get;
            set;
        }

        /// <summary>
        /// The y coordinate on the board.
        /// </summary>
        public int BoardY
        {
            get;
            set;
        }

        /// <summary>
        /// The x coordinate of the sprite.
        /// </summary>
        public int CanvasX
        {
            get;
            set;
        }

        /// <summary>
        /// The y coordinate of the sprite.
        /// </summary>
        public int CanvasY
        {
            get;
            set;
        }

        public Texture2D Sprite
        {
            get;
            set;
        }

        #endregion
    }
}
