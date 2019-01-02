namespace Manastream.Src.GameResources
{
    #region Usings
    
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The resources class that contains the game resources.
    /// </summary>
    public class Resources
    {
        #region Fields

        private static Resources resources;
        private Textures textures;

        #endregion

        #region Properties

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Resources"/> class.
        /// </summary>
        public Resources()
        {
            this.textures = new Textures();
        }

        #endregion

        public Textures Textures => textures;

        public GraphicsDevice GraphicsDevice
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the instance of the <see cref="Resources"/> class.
        /// </summary>
        public static Resources GetInstance()
        {
            if (resources == null)
            {
                resources = new Resources();
            }

            return resources;
        }

        #endregion
    }
}
