namespace Manastream.Src.UI.Components.Complex
{
    #region Usings

    using Manastream.Src.UI.Components.Basic;
    using Manastream.Src.UI.PositionProfiles;
    using System.Collections.Generic;

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
            private set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a lsit of the descendant components.
        /// </summary>
        public virtual List<ComplexUIComponent> GetDescendants()
        {
            return new List<ComplexUIComponent>() { this };
        }

        /// <summary>
        /// Sets the component to hovered and executes the on hover handler.
        /// </summary>
        public void Hover()
        {
            Hovered = true;
            OnHover();
        }

        /// <summary>
        /// Sets the component to not hovered and executes the on hover leave handler.
        /// </summary>
        public void HoverLeave()
        {
            Hovered = false;
            OnHoverLeave();
        }

        /// <summary>
        /// On hover handler.
        /// </summary>
        protected virtual void OnHover() { }

        /// <summary>
        /// On hover leave handler.
        /// </summary>
        protected virtual void OnHoverLeave() { }

        #endregion
    }
}
