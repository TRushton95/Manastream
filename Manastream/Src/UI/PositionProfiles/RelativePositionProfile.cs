namespace Manastream.Src.UI.PositionProfiles
{
    #region Usings

    using Manastream.Src.UI.Enums;
    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The relative position profile that defines a position relative to a parent container.
    /// </summary>
    public class RelativePositionProfile : IPositionProfile
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="RelativePositionProfile"/> class.
        /// </summary>
        public RelativePositionProfile(HorizontalAlign horizontalAlign, VerticalAlign verticalAlign, int offsetX, int offsetY)
        {
            this.HorizontalAlign = horizontalAlign;
            this.VerticalAlign = VerticalAlign;
            this.OffsetX = offsetX;
            this.OffsetY = offsetY;
        }

        #endregion

        #region Properties

        public HorizontalAlign HorizontalAlign
        {
            get;
            set;
        }

        public VerticalAlign VerticalAlign
        {
            get;
            set;
        }

        public int OffsetX
        {
            get;
            set;
        }

        public int OffsetY
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the position of the component relative to its parent.
        /// </summary>
        public Vector2 GetPosition(Rectangle bounds, Rectangle parentBounds)
        {
            int resultX = parentBounds.X + OffsetX;

            switch (HorizontalAlign)
            {
                case HorizontalAlign.Center:
                    resultX += (parentBounds.Width / 2) - (bounds.Width / 2);
                    break;

                case HorizontalAlign.Right:
                    resultX += parentBounds.Width - bounds.Width;
                    break;
            }

            int resultY = parentBounds.Y + OffsetY;

            switch (VerticalAlign)
            {
                case VerticalAlign.Center:
                    resultY += (parentBounds.Height / 2) - (bounds.Height / 2);
                    break;

                case VerticalAlign.Bottom:
                    resultY += parentBounds.Height - bounds.Height;
                    break;
            }

            return new Vector2(resultX, resultY);
        }

        #endregion
    }
}
