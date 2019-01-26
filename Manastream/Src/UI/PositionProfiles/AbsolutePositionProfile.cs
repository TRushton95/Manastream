using Microsoft.Xna.Framework;

namespace Manastream.Src.UI.PositionProfiles
{
    public class AbsolutePositionProfile : IPositionProfile
    {
        #region Constructors

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
            private set;
        }

        public int PosY
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public Vector2 GetPosition(Rectangle bounds, Rectangle parentBounds)
        {
            return new Vector2(PosX, PosY);
        }

        #endregion
    }
}
