namespace Manastream.Src.Gameplay.Abilities.Templates
{
    #region Usings

    using Manastream.Src.Gameplay.Enums;

    #endregion

    /// <summary>
    /// The area effect template.
    /// </summary>
    public class AreaEffectTemplate : Template
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="AreaEffectTemplate"/> class.
        /// </summary>
        public AreaEffectTemplate(int radius)
            : base(TemplateType.AreaEffect)
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
