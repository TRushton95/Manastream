namespace Manastream.Src.Gameplay.Entities
{
    #region Usings

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    #endregion

    /// <summary>
    /// The camera class that provides translation matrices for game actors.
    /// </summary>
    public class Camera
    {
        #region Constants

        private const int DefaultSpeed = 10;

        #endregion

        #region Fields
        
        private int canvasX, canvasY;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Camera"/> class.
        /// </summary>
        public Camera(int canvasX, int canvasY, bool enabled = true, int speed = DefaultSpeed)
        {
            this.canvasX = canvasX;
            this.canvasY = canvasY;
            this.Speed = speed;
            this.Enabled = enabled;
        }

        #endregion

        #region Properties

        public int Speed
        {
            get;
            set;
        }

        public bool Enabled
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Update the location of the camera.
        /// </summary>
        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.W))
            {
                canvasY -= Speed;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                canvasX -= Speed;
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                canvasY += Speed;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                canvasX += Speed;
            }
        }

        /// <summary>
        /// Set the location of the camera to a new location.
        /// </summary>
        public void SetLocation(int canvasX, int canvasY)
        {
            this.canvasX = canvasX;
            this.canvasY = canvasY;
        }

        /// <summary>
        /// Reset the location of the camera to the origin.
        /// </summary>
        public void ResetLocation()
        {
            canvasX = 0;
            canvasY = 0;
        }

        /// <summary>
        /// Get the translation matrix for the current camera location.
        /// </summary>
        public Matrix GetTranslationMatrix()
        {
            return Matrix.CreateTranslation(-canvasX, -canvasY, 0);
        }

        #endregion
    }
}
