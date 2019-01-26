namespace Manastream.Src.UI.PositionProfiles
{
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
        public AbsolutePositionProfile(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        #endregion

        #region Properties

        public int PosX
        {
            get;
            set;
        }

        public int PosY
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
            return new Vector2(PosX, PosY);
        }

        #endregion
    }
}
