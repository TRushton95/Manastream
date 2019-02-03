namespace Manastream.Src.UI.Components.Complex
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.UI.Components.Basic;
    using Manastream.Src.UI.Factories;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The health bar component.
    /// </summary>
    public class HealthBar : UIComponent
    {
        #region Fields

        private int prevHealth;
        private Unit unit;
        private Frame frame;

        #endregion

        /// <summary>
        /// Initialises a new instance of the <see cref="HealthBar"/> class.
        /// </summary>
        #region Constructors

        public HealthBar(int width, int height, IPositionProfile positionProfile, Unit unit)
            : base(width, height, positionProfile)
        {
            this.unit = unit;
            BuildComponents();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the component.
        /// </summary>
        public override void Update()
        {
            if (unit == null)
            {
                return;
            }

            if (prevHealth != unit.CurrentHealth)
            {
                InitialiseComponents();
            }

            prevHealth = unit.CurrentHealth;
        }

        /// <summary>
        /// Initialises the UI component.
        /// </summary>
        public override void Initialise(Rectangle parent)
        {
            InitialiseComponents();
            InitialiseCoordinates(parent);
        }

        /// <summary>
        /// Draws the UI component.
        /// </summary>
        protected override void DrawDetail(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);
        }

        /// <summary>
        /// Buikds the constituant components.
        /// </summary>
        private void BuildComponents()
        {
            frame = new Frame(ZeroAdjustedWidth(unit.CurrentHealth, unit.MaxHealth), 50, PositionProfileFactory.BuildCenteredRelative(), Color.Green);
        }

        /// <summary>
        /// Initialises the constituant components.
        /// </summary>
        private void InitialiseComponents()
        {
            frame.Initialise(GetBounds());
        }
        
        /// <summary>
        /// Gets the width of a resource frame, returning the max width if the value is 0.
        /// </summary>
        private int ZeroAdjustedWidth(double current, double max)
        {
            int resourceWidth = (int)(Width * (current / max));
            return resourceWidth > 0 ? resourceWidth : Width;
        }

        #endregion
    }
}
