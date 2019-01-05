namespace Manastream.Src.Gameplay.Abilities.Templates
{
    /// <summary>
    /// The area effect template.
    /// </summary>
    public class AreaEffectTemplate
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="AreaEffectTemplate"/> class.
        /// </summary>
        public AreaEffectTemplate(int radius)
        {
            this.Radius = radius;
        }

        #endregion

        #region Properties

        public int Radius
        {
            get;
            set;
        }

        #endregion
    }
}
