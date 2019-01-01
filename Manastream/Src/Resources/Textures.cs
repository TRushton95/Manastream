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

        private string TilePathName = "Tiles";
        private string UnitPathName = "Units";

        #endregion

        #region Fields

        private static Textures textures;

        //Tiles
        private static Texture2D emptyTile, groundTile;

        //Units
        private static Texture2D blueUnit, redUnit;

        #endregion

        #region Getters

        //Tiles
        public Texture2D EmptyTile => emptyTile;
        public Texture2D GroundTile => groundTile;

        //Units
        public Texture2D BlueUnit => blueUnit;
        public Texture2D RedUnit => redUnit;

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
            InitialiseUnits(content);
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

        /// <summary>
        /// Initialises the unit textures.
        /// </summary>
        private void InitialiseUnits(ContentManager content)
        {
            blueUnit = LoadUnitTexture(content, "BlueUnit");
            redUnit = LoadUnitTexture(content, "RedUnit");
        }

        #endregion

        #region Section Loading

        /// <summary>
        /// Loads a tile texture.
        /// </summary>
        private Texture2D LoadTileTexture(ContentManager content, string tileTextureName)
        {
            return content.Load<Texture2D>(Path.Combine(TilePathName, tileTextureName));
        }

        /// <summary>
        /// Loads a unit texture.
        /// </summary>
        private Texture2D LoadUnitTexture(ContentManager content, string unitTextureName)
        {
            return content.Load<Texture2D>(Path.Combine(UnitPathName, unitTextureName));
        }

        #endregion
    }
}
