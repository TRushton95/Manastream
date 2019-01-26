namespace Manastream.Src.UI.Components
{
    #region Usings

    using Manastream.Src.GameResources;
    using Manastream.Src.UI.Components.Complex;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

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
        /// Gets all the components in the tree.
        /// </summary>
        public List<ComplexUIComponent> GetAllComponents()
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
