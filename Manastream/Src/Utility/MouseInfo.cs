namespace Manastream.Src.Utility
{
    #region Usings

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    #endregion

    /// <summary>
    /// A wrapper class for <see cref="MouseState"/> that provides easy access to check the changing of mouse states.
    /// </summary>
    public static class MouseInfo
    {
        #region Fields

        private static MouseState previousMouseState, currentMouseState;

        #endregion

        #region Methods

        /// <summary>
        /// Updates the mouse state.
        /// </summary>
        public static void Update()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the x position of the mouse.
        /// </summary>
        public static int X => currentMouseState.X;

        /// <summary>
        /// Gets the y position of the mouse.
        /// </summary>
        public static int Y => currentMouseState.Y;

        /// <summary>
        /// Gets the position of the mouse.
        /// </summary>
        public static Point Position => currentMouseState.Position;

        /// <summary>
        /// Checks if the left mouse button is currently down.
        /// </summary>
        public static bool LeftMouseDown => currentMouseState.LeftButton == ButtonState.Pressed;

        /// <summary>
        /// Checks if the right mouse button is currently down.
        /// </summary>
        public static bool RightMouseDown => currentMouseState.RightButton == ButtonState.Pressed;

        /// <summary>
        /// Checks if the left mouse button has just been pressed.
        /// </summary>
        public static bool LeftMousePressed => currentMouseState.LeftButton == ButtonState.Pressed &&
                                                previousMouseState.LeftButton == ButtonState.Released;

        /// <summary>
        /// Checks if the right mouse button has just been pressed.
        /// </summary>
        public static bool RightMousePressed => currentMouseState.RightButton == ButtonState.Pressed &&
                                                    previousMouseState.RightButton == ButtonState.Released;

        /// <summary>
        /// Checks if the left mouse button has just been released.
        /// </summary>
        public static bool LeftMouseReleased => currentMouseState.LeftButton == ButtonState.Released &&
                                                previousMouseState.LeftButton == ButtonState.Pressed;

        /// <summary>
        /// Checks if the right mouse button has just been released.
        /// </summary>
        public static bool RightMouseReleased => currentMouseState.RightButton == ButtonState.Released &&
                                                    previousMouseState.RightButton == ButtonState.Pressed;

        /// <summary>
        /// Checks if the left mouse button has been held since the previous state.
        /// </summary>
        public static bool LeftMouseHeld => currentMouseState.LeftButton == ButtonState.Pressed &&
                                            previousMouseState.LeftButton == ButtonState.Pressed;

        /// <summary>
        /// Checks if the right mouse button has been held since the previous state.
        /// </summary>
        public static bool RightMouseHeld => currentMouseState.RightButton == ButtonState.Pressed &&
                                                previousMouseState.RightButton == ButtonState.Pressed;

        /// <summary>
        /// Checks if the mouse has moved since the previous state.
        /// </summary>
        public static bool MouseMoved => currentMouseState.Position != previousMouseState.Position;

        /// <summary>
        /// Checks if the left mouse button has held and dragged since the previous state.
        /// </summary>
        public static bool LeftMouseDragged => LeftMouseHeld && MouseMoved;

        /// <summary>
        /// Checks if the right mouse button has been held and dragged since the previous state.
        /// </summary>
        public static bool RightMouseDragged => RightMouseHeld && MouseMoved;

        /// <summary>
        /// Gets the scroll wheel value.
        /// </summary>
        public static int ScrollWheelValue => currentMouseState.ScrollWheelValue;

        /// <summary>
        /// Gets the amount that the scroll wheel value has changed since the previous input state.
        /// </summary>
        public static int ScrollWheelChange => currentMouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue;

        #endregion
    }
}
