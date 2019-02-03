﻿namespace Manastream.Src.UI.Components.Complex
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.EventSystem.Events;
    using Manastream.Src.EventSystem.Events.Debug;
    using Manastream.Src.Gameplay.Entities.Actors;
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
            this.AddEventHandler(EventTypes.Debug.SelectUnit, OnSelectUnit);

            BuildComponents();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the UI component.
        /// </summary>
        public override void Update()
        {
            if (!Visible)
            {
                return;
            }

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
        /// Initialises the UI component.
        /// </summary>
        public override void Initialise(Rectangle parent)
        {
            InitialiseCoordinates(parent);
            InitialiseComponents();
        }

        /// <summary>
        /// Defines the implementation details of the Draw method.
        /// </summary>
        protected override void DrawDetail(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);
        }

        /// <summary>
        /// Builds the constituant components.
        /// </summary>
        private void BuildComponents()
        {
            frame = new Frame(Width, Height, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Center, 0, 0), Color.Black);

            FontGraphics nameFontGraphics = new FontGraphics(unit.Name, Width, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, 10), TextFormat.Shrink, Color.White, Resources.Textures.Debug);
            frame.Components.Add(nameFontGraphics);

            //Health bar
            Color healthColour = unit.CurrentHealth == 0 ? Color.Transparent : Color.Green;

            FontGraphics healthFontGraphics = new FontGraphics(string.Format(ResourceText, unit.CurrentHealth, unit.MaxHealth), Width, PositionProfileFactory.BuildCenteredRelative(), TextFormat.Shrink, Color.White, Resources.Textures.Debug);
            Frame healthFrame = new Frame(Width, 50, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, 50), Color.Black);
            Frame health = new Frame(ZeroAdjustedWidth(unit.CurrentHealth, unit.MaxHealth), 50, new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Center, 0, 0), healthColour);

            healthFrame.Components.Add(health);
            healthFrame.Components.Add(healthFontGraphics);
            frame.Components.Add(healthFrame);

            //Energy bar
            Color energyColour = unit.CurrentEnergy == 0 ? Color.Transparent : Color.RoyalBlue;

            FontGraphics energyFontGraphics = new FontGraphics(string.Format(ResourceText, unit.CurrentEnergy, unit.MaxEnergy), Width, PositionProfileFactory.BuildCenteredRelative(), TextFormat.Shrink, Color.White, Resources.Textures.Debug);
            Frame energyFrame = new Frame(Width, 50, new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, 100), Color.Black);
            Frame energy = new Frame(ZeroAdjustedWidth(unit.CurrentEnergy, unit.MaxEnergy), 50, new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Center, 0, 0), energyColour);

            energyFrame.Components.Add(energy);
            energyFrame.Components.Add(energyFontGraphics);
            frame.Components.Add(energyFrame);
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

        #region Event Handlers

        public void OnSelectUnit(Event e)
        {
            SelectUnitEvent args = (SelectUnitEvent)e;

            unit = args.SelectedUnit;

            if (unit == null)
            {
                Hide();
            }
            else
            {
                BuildComponents();
                InitialiseComponents();
                Show();
            }
        }

        #endregion
    }
}
