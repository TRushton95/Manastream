namespace Manastream.Src.UI.Components.Complex
{
    #region Usings
    
    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.Gameplay.Enums;
    using Manastream.Src.UI.Components.Basic;
    using Manastream.Src.UI.Factories;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Shared.Enums;

    #endregion

    /// <summary>
    /// The health bar component.
    /// </summary>
    public class HealthBar : UIComponent
    {
        #region Fields

        private int prevHealth;
        private Frame frame;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="HealthBar"/> class.
        /// </summary>
        public HealthBar(int id, int width, int height, IPositionProfile positionProfile, DrawLayer drawLayer, Unit unit)
            : base(id, width, height, positionProfile, drawLayer)
        {
            this.Unit = unit;

            BuildComponents();
        }

        #endregion

        #region Properties

        public Unit Unit
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the component.
        /// </summary>
        public override void Update(Rectangle parent)
        {
            UpdateCoordinates(parent);

            if (Unit == null)
            {
                return;
            }

            if (prevHealth != Unit.CurrentHealth)
            {
                BuildComponents();
                InitialiseComponents();
            }

            prevHealth = Unit.CurrentHealth;
        }

        /// <summary>
        /// Initialises the UI component.
        /// </summary>
        public override void Initialise(Rectangle parent)
        {
            SetCoordinates(parent);
            InitialiseComponents();
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
            Frame currentHealthframe = new Frame(ZeroAdjustedWidth(Unit.CurrentHealth, Unit.MaxHealth), Height, PositionProfileFactory.CenteredLeftRelative(), DrawLayer, Color.SpringGreen);
            frame = new Frame(Width, Height, PositionProfileFactory.BuildCenteredRelative(), DrawLayer, Color.Red);
            frame.Components.Add(currentHealthframe);
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

        /// <summary>
        /// Updates the coordinates of the UI component and it's composite components.
        /// </summary>
        protected override void UpdateCoordinates(Rectangle parent)
        {
            SetCoordinates(parent);
            frame.Update(GetBounds());
        }

        #endregion
    }
}
