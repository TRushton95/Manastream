namespace Manastream.Src.UI.PositionProfiles
{
    using Manastream.Src.DataStructures;
    #region Usings

    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The absolute position profile that defines a set of absolute coordinates.
    /// </summary>
    public class AbsolutePositionProfile : IPositionProfile
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="AbsolutePositionProfile"/> class.
        /// </summary>
        public AbsolutePositionProfile(Position anchorPoint, int offsetX, int offsetY)
        {
            this.AnchorPoint = anchorPoint;
            this.OffsetX = offsetX;
            this.OffsetY = offsetY;
        }

        #endregion

        #region Properties

        public Position AnchorPoint
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
        /// Gets the position of the component.
        /// </summary>
        public Vector2 GetPosition(Rectangle bounds, Rectangle parentBounds)
        {
            return AnchorPoint.ToVector2() - new Vector2(OffsetX, OffsetY);
        }

        #endregion
    }
}
