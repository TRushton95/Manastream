namespace Manastream.Src.UI.PositionProfiles
{
    #region Usings

    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The position profile interface that defines a contract for the position profiles.
    /// </summary>
    public interface IPositionProfile
    {
        /// <summary>
        /// Gets the position of the component.
        /// </summary>
        Vector2 GetPosition(Rectangle bounds, Rectangle parentBounds);
    }
}
