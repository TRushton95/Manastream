namespace Manastream.Src.UI.Components.Complex
{
    #region Usings

    using Manastream.Src.UI.Components.Basic;
    using Manastream.Src.UI.PositionProfiles;

    #endregion

    /// <summary>
    /// The complex ui component class that represents a usable component, built out of base UI components.
    /// </summary>
    public abstract class ComplexUIComponent : UIComponent
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ComplexUIComponent"/> class.
        /// </summary>
        public ComplexUIComponent(int width, int height, IPositionProfile positionProfile)
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
