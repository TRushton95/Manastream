namespace Manastream.Src.UI.Components
{
    #region Usings

    using Manastream.Src.GameResources;
    using Manastream.Src.UI.Components.Complex;
    using Manastream.Src.Utility;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    /// <summary>
    /// The user interface class that holds the ui components and allows manipulation of them.
    /// </summary>
    public class UserInterface
    {
        #region Fields

        private Resources resources => Resources.GetInstance();

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="UserInterface"/> class.
        /// </summary>
        public UserInterface()
        {
            this.Components = new List<ComplexUIComponent>();
        }

        #endregion

        #region Properties

        public List<ComplexUIComponent> Components
        {
            get;
        }

        public ComplexUIComponent PrevHoveredComponent
        {
            get;
            private set;
        }

        public ComplexUIComponent HoveredComponent
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialises the user interface.
        /// </summary>
        public void Initialise()
        {
            foreach (ComplexUIComponent component in Components)
            {
                Rectangle window = resources.GraphicsDevice.Viewport.Bounds;
                component.Initialise(window);
            }
        }

        /// <summary>
        /// Draws the user interface.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ComplexUIComponent component in Components)
            {
                component.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Updates the highest priority hovered component.
        /// </summary>
        public void UpdateHoveredComponent()
        {
            List<ComplexUIComponent> hoveredComponents = GetAllComponents().Where(c => c.GetBounds().Contains(MouseInfo.Position)).ToList();

            ComplexUIComponent nextHoveredComponent = null;

            if (hoveredComponents.Count > 0)
            {
                nextHoveredComponent = hoveredComponents.First(); // TO-DO Select highest priority component
            }

            PrevHoveredComponent = HoveredComponent;
            HoveredComponent = nextHoveredComponent;

            if (HoveredComponent == PrevHoveredComponent)
            {
                return;
            }

            if (PrevHoveredComponent != null)
            {
                PrevHoveredComponent.HoverLeave();
            }

            if (HoveredComponent != null)
            {
                HoveredComponent.Hover();
            }
        }

        /// <summary>
        /// Gets all the components in the tree.
        /// TO-DO The AllComponents list should be stored in a property and updated when a component update notification is received - avoids
        /// rebuilding the list every time it is required.
        /// </summary>
        private List<ComplexUIComponent> GetAllComponents()
        {
            List<ComplexUIComponent> results = new List<ComplexUIComponent>();

            foreach (ComplexUIComponent component in Components)
            {
                results.AddRange(component.GetDescendants());
            }

            return results;
        }

        #endregion
    }
}
