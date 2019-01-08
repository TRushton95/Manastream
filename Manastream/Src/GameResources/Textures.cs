namespace Manastream.Src.GameResources
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
        
        private bool initialised = false;

        //Tiles
        private static Texture2D tileHighlight, unitSelect;
        private static Texture2D emptyTile, groundTile;
        private static Texture2D greenTileFilter, redTileFilter, moveArrow;

        //Units
        private static Texture2D wizard, knight;

        #endregion

        #region Properties

        //Tiles
        public Texture2D TileHighlight => tileHighlight;
        public Texture2D UnitSelect => unitSelect;
        public Texture2D EmptyTile => emptyTile;
        public Texture2D GroundTile => groundTile;
        public Texture2D GreenTileFilter => greenTileFilter;
        public Texture2D RedTileFilter => redTileFilter;
        public Texture2D MoveArrow => moveArrow;

        //Units
        public Texture2D Wizard => wizard;
        public Texture2D Knight => knight;

        #endregion

        #region Methods
        
        /// <summary>
        /// Initialise the textures.
        /// </summary>
        public void Initialise(ContentManager content)
        {
            if (initialised)
            {
                return;
            }

            InitialiseTiles(content);
            InitialiseUnits(content);

            initialised = true;
        }

        #endregion

        #region Section Initialising

        /// <summary>
        /// Initialises the tile textures.
        /// </summary>
        private void InitialiseTiles(ContentManager content)
        {
            tileHighlight = LoadTileTexture(content, "TileHighlight");
            unitSelect = LoadTileTexture(content, "UnitSelect");
            emptyTile = LoadTileTexture(content, "EmptyTile");
            groundTile = LoadTileTexture(content, "GroundTile");
            redTileFilter = LoadTileTexture(content, "RedTileFilter");
            greenTileFilter = LoadTileTexture(content, "GreenTileFilter");
            moveArrow = LoadTileTexture(content, "MoveArrow");
        }

        /// <summary>
        /// Initialises the unit textures.
        /// </summary>
        private void InitialiseUnits(ContentManager content)
        {
            wizard = LoadUnitTexture(content, "Wizard");
            knight = LoadUnitTexture(content, "Knight");
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
