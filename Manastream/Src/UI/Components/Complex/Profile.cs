namespace Manastream.Src.UI.Components.Complex
{
    #region Usings

    using Manastream.Src.UI.Components.Basic;
    using Manastream.Src.UI.Enums;
    using Manastream.Src.UI.Factories;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The profile component that displays a unit's information.
    /// </summary>
    public class Profile : ComplexUIComponent
    {
        #region Constants

        private const int ProfileWidth = 300;
        private const int ProfileHeight = 150;

        #endregion

        #region Fields

        private int currentHealth, maxHealth, currentEnergy, maxEnergy;
        private Frame frame;
        private string nameText, healthText, energyText;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Profile"/> class.
        /// </summary>
        public Profile(string name, int currentHealth, int maxHealth, int currentEnergy, int maxEnergy, IPositionProfile positionProfile)
            : base(ProfileWidth, ProfileHeight, positionProfile)
        {
            this.nameText = name;
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
            this.currentEnergy = currentEnergy;
            this.maxEnergy = maxEnergy;

            healthText = $"{currentHealth}/{maxHealth}";
            energyText = $"{currentEnergy}/{maxEnergy}";

            BuildComponents();
        }

        #endregion

        #region Methods

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
        public void BuildComponents()
        {
            FontGraphics nameFontGraphics = new FontGraphics(nameText, Width, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, 10), TextFormat.Shrink, Color.White, Resources.Textures.Debug);

            FontGraphics healthFontGraphics = new FontGraphics(healthText, Width, PositionProfileFactory.BuildCenteredRelative(), TextFormat.Shrink, Color.White, Resources.Textures.Debug);
            Frame healthFrame = new Frame(Width, 50, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, 50), Color.Black);
            Frame health = new Frame(Width / 2, 50, new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Center, 0, 0), Color.Green);
            healthFrame.Components.Add(health);

            healthFrame.Components.Add(healthFontGraphics);

            FontGraphics energyFontGraphics = new FontGraphics(energyText, Width, PositionProfileFactory.BuildCenteredRelative(), TextFormat.Shrink, Color.White, Resources.Textures.Debug);
            Frame energyFrame = new Frame(Width, 50, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, 100), Color.Black);
            Frame energy = new Frame((Width / 5) * 2, 50, new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Center, 0, 0), Color.Yellow);
            energyFrame.Components.Add(energy);

            energyFrame.Components.Add(energyFontGraphics);

            frame = new Frame(Width, Height, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), Color.Black);
            frame.Components.Add(nameFontGraphics);
            frame.Components.Add(healthFrame);
            frame.Components.Add(energyFrame);
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
