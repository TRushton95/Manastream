namespace Manastream.Src.UI.Factories
{
    #region Usings

    using Manastream.Src.UI.Enums;
    using Manastream.Src.UI.PositionProfiles;

    #endregion

    /// <summary>
    /// The position profile factory that provides easy creation of preset position profiles.
    /// </summary>
    public static class PositionProfileFactory
    {
        #region Methods

        /// <summary>
        /// A relative position profile that is centered in the parent element.
        /// </summary>
        public static RelativePositionProfile BuildCenteredRelative()
        {
            return new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0);
        }

        /// <summary>
        /// A relative position profile that is centered at the top of the parent element.
        /// </summary>
        public static RelativePositionProfile TopCenteredRelative(int topOffset = 0)
        {
            return new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, topOffset);
        }

        #endregion
    }
}
