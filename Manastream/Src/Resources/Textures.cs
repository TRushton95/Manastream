namespace Manastream.Src.Resources
{
    #region Usings

    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System.IO;

    #endregion

    /// <summary>
    /// The textures class that loads all game textures.
    /// </summary>
    public class Textures
    {
        #region Constants

        private string TilesPathName = "Tiles";

        #endregion

        #region Fields

        private static Textures textures;

        //Tiles
        private static Texture2D emptyTile, groundTile;

        #endregion

        #region Getters

        //Tiles
        public Texture2D EmptyTile => emptyTile;
        public Texture2D GroundTile => groundTile;

        #endregion

        #region Methods

        /// <summary>
        /// Gets the instance of the <see cref="Textures"/> class.
        /// </summary>
        public static Textures GetInstance()
        {
            if (textures == null)
            {
                textures = new Textures();
            }

            return textures;
        }
        
        /// <summary>
        /// Initialise the textures.
        /// </summary>
        public void Initialise(ContentManager content)
        {
            InitialiseTiles(content);
        }

        #endregion

        #region Section Initialising

        /// <summary>
        /// Initialises the tile textures.
        /// </summary>
        private void InitialiseTiles(ContentManager content)
        {
            emptyTile = LoadTileTexture(content, "EmptyTile");
            groundTile = LoadTileTexture(content, "GroundTile");
        }

        #endregion

        #region Section Loading

        /// <summary>
        /// Loads a tile texture.
        /// </summary>
        private Texture2D LoadTileTexture(ContentManager content, string tileTextureName)
        {
            return content.Load<Texture2D>(Path.Combine(TilesPathName, tileTextureName));
        }

        #endregion
    }
}
