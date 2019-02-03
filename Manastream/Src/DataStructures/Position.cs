namespace Manastream.Src.DataStructures
{
    #region Usings

    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The position class.
    /// </summary>
    public class Position
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Position"/> class.
        /// </summary>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion

        #region Properties

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the position as a <see cref="Vector2"/> class.
        /// </summary>
        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        #endregion
    }
}
