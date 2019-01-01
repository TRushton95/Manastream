namespace Manastream.Src.GameResources
{
    /// <summary>
    /// The resources class that contains the game resources.
    /// </summary>
    public class Resources
    {
        #region Fields

        private static Resources resources;

        #endregion

        #region Properties

        public Textures Textures => Textures.GetInstance();

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
