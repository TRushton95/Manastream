namespace Manastream.Src.Gameplay.Entities.Actor
{
    #region Usings

    using Manastream.Src.GameResources;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The game actor base class representing any entity that exists on the <see cref="Board"/>.
    /// </summary>
    public abstract class GameActor
    {
        #region Constructors

        /// <summary>C:\Github\Manastream\Manastream\Src\Gameplay\Entities\Actors\GameActor.cs
        /// Initialises a new instance of the <see cref="GameActor"/> class.
        /// </summary>
        public GameActor(int boardX, int boardY, int canvasX, int canvasY, Texture2D texture)
        {
            this.BoardX = boardX;
            this.BoardY = boardY;
            this.CanvasX = canvasX;
            this.CanvasY = canvasY;
            this.Texture = texture;
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
        /// The x coordinate of the texture.
        /// </summary>
        public int CanvasX
        {
            get;
            set;
        }

        /// <summary>
        /// The y coordinate of the texture.
        /// </summary>
        public int CanvasY
        {
            get;
            set;
        }

        public Texture2D Texture
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
        /// Renders the game actor.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Vector2(CanvasX, CanvasY), Color.White);
        }

        #endregion
    }
}
