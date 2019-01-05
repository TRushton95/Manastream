namespace Manastream.Src.Gameplay.Abilities.Templates
{
    #region Usings

    using Manastream.Src.Gameplay.Enums;

    #endregion

    public class Template
    {
        #region Constructors

        public Template(TemplateType templateType)
        {
            this.TemplateType = templateType;
        }

        #endregion

        #region Properties

        public TemplateType TemplateType
        {
            get;
        }

        #endregion
    }
}
