namespace Manastream.Src.UI.Components.Complex
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;
    using Manastream.Src.UI.Components.Basic;
    using Manastream.Src.UI.Enums;
    using Manastream.Src.UI.Factories;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    /// <summary>
    /// The profile component that displays a unit's information.
    /// </summary>
    public class Profile : ComplexUIComponent
    {
        #region Constants

        private const int ProfileWidth = 300;
        private const int ProfileHeight = 150;
        private const string ResourceText = "{0}/{1}";

        #endregion

        #region Fields
        
        private Frame frame;
        private Unit unit;
        private int prevHealth, prevEnergy;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Profile"/> class.
        /// </summary>
        public Profile(Unit unit, IPositionProfile positionProfile)
            : base(ProfileWidth, ProfileHeight, positionProfile)
        {
            this.unit = unit;

            BuildComponents();
        }

        #endregion

        #region Methods

        public override void Update()
        {
            if (prevHealth != unit.CurrentHealth ||
                prevEnergy != unit.CurrentEnergy)
            {
                BuildComponents();
                InitialiseComponents();
            }

            prevHealth = unit.CurrentHealth;
            prevEnergy = unit.CurrentEnergy;
        }

        /// <summary>
        /// Draws the UI component.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);
        }

        /// <summary>
        /// Initialises the UI component.
        /// </summary>
        public override void Initialise(Rectangle parent)
        {
            InitialiseCoordinates(parent);
            InitialiseComponents();
        }

        /// <summary>
        /// Builds the constituant components.
        /// </summary>
        private void BuildComponents()
        {
            frame = new Frame(Width, Height, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), Color.Black);

            FontGraphics nameFontGraphics = new FontGraphics(unit.Name, Width, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, 10), TextFormat.Shrink, Color.White, Resources.Textures.Debug);
            frame.Components.Add(nameFontGraphics);

            if (unit.CurrentHealth > 0)
            {
                FontGraphics healthFontGraphics = new FontGraphics(string.Format(ResourceText, unit.CurrentHealth, unit.MaxHealth), Width, PositionProfileFactory.BuildCenteredRelative(), TextFormat.Shrink, Color.White, Resources.Textures.Debug);
                Frame healthFrame = new Frame(Width, 50, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, 50), Color.Black);
                Frame health = new Frame((int)(Width * ((double)unit.CurrentHealth / unit.MaxHealth)), 50, new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Center, 0, 0), Color.Green);

                healthFrame.Components.Add(health);
                healthFrame.Components.Add(healthFontGraphics);
                frame.Components.Add(healthFrame);
            }

            if (unit.CurrentEnergy > 0)
            {
                FontGraphics energyFontGraphics = new FontGraphics(string.Format(ResourceText, unit.CurrentEnergy, unit.MaxEnergy), Width, PositionProfileFactory.BuildCenteredRelative(), TextFormat.Shrink, Color.White, Resources.Textures.Debug);
                Frame energyFrame = new Frame(Width, 50, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, 100), Color.Black);
                Frame energy = new Frame((int)(Width * ((double)unit.CurrentEnergy / unit.MaxEnergy)), 50, new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Center, 0, 0), Color.RoyalBlue);

                energyFrame.Components.Add(energy);
                energyFrame.Components.Add(energyFontGraphics);
                frame.Components.Add(energyFrame);
            }
        }

        /// <summary>
        /// Initialises the constituant components.
        /// </summary>
        private void InitialiseComponents()
        {
            frame.Initialise(GetBounds());
        }

        #endregion
    }
}
