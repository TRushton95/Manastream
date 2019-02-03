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
            this.Components = new List<UIComponent>();
        }

        #endregion

        #region Properties

        public List<UIComponent> Components
        {
            get;
            set;
        }

        public UIComponent PrevHoveredComponent
        {
            get;
            private set;
        }

        public UIComponent HoveredComponent
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
            foreach (UIComponent component in Components)
            {
                Rectangle window = resources.GraphicsDevice.Viewport.Bounds;
                component.Initialise(window);
            }
        }

        /// <summary>
        /// Updates the user interface.
        /// </summary>
        public void Update()
        {
            foreach (UIComponent component in Components)
            {
                component.Update();
            }

            UpdateHoveredComponent();
        }

        /// <summary>
        /// Draws the user interface.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (UIComponent component in Components)
            {
                component.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Updates the highest priority hovered component.
        /// </summary>
        private void UpdateHoveredComponent()
        {
            List<UIComponent> hoveredComponents = GetAllComponents().Where(c => c.GetBounds().Contains(MouseInfo.Position)).ToList();

            UIComponent nextHoveredComponent = null;

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
        private List<UIComponent> GetAllComponents()
        {
            List<UIComponent> results = new List<UIComponent>();

            foreach (UIComponent component in Components)
            {
                results.AddRange(component.GetDescendants());
            }

            return results;
        }

        #endregion
    }
}
