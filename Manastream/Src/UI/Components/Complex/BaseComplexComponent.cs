namespace Manastream.Src.UI.Components.Complex
{
    #region Usings

    using Manastream.Src.UI.Components.Basic;
    using Manastream.Src.UI.PositionProfiles;

    #endregion

    public abstract class BaseComplexComponent : BaseComponent
    {
        #region Constructors

        public BaseComplexComponent(int width, int height, IPositionProfile positionProfile)
            : base(positionProfile)
        {
            this.Width = width;
            this.Height = height;
        }

        #endregion

        #region Methods
        
        public bool Hovered
        {
            get;
            set;
        }

        public bool Visible
        {
            get;
            set;
        }

        #endregion
    }
}
