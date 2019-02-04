namespace Manastream.Src.UI.Components.Basic
{
    #region Usings

    using Manastream.Src.EventSystem.Events.Graphics;
    using Manastream.Src.Gameplay.Enums;
    using Manastream.Src.UI.Enums;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Text;

    #endregion

    /// <summary>
    /// The font graphics class that displays text within a specified width, either shrinking or wrapping when exceeding the width.
    /// </summary>
    public class FontGraphics : BasicUIComponent
    {
        #region Fields

        private string text, displayText;
        private SpriteFont font;
        private float scale;
        private int maxWidth;
        private TextFormat fontFlow;
        private Color colour;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="FontGraphics"/> class.
        /// </summary>
        public FontGraphics(string text, int maxWidth, IPositionProfile positionProfile, DrawLayer drawLayer, TextFormat fontFlow, Color colour, SpriteFont font)
            : base(positionProfile, drawLayer)
        {
            this.text = text;
            this.displayText = text;
            this.maxWidth = maxWidth;
            this.fontFlow = fontFlow;
            this.colour = colour;
            this.font = font;
            this.scale = 1;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the text.
        /// </summary>
        public override void Update(Rectangle parent)
        {
            SetCoordinates(parent);
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            eventManager.Notify(new StringDrawReadyEvent(displayText, font, GetCoordinates(), scale, colour, DrawLayer));
        }

        /// <summary>
        /// Initialises the font graphics.
        /// </summary>
        public override void Initialise(Rectangle parent)
        {
            FormatText();
            InitialiseDimensions();
            SetCoordinates(parent);
        }

        /// <summary>
        /// Adjusts the text if it has exceeding its maximum width.
        /// </summary>
        private void FormatText()
        {
            Vector2 dimensions = font.MeasureString(displayText);

            if (dimensions.X <= maxWidth)
            {
                return;
            }

            switch (fontFlow)
            {
                case TextFormat.Wrap:
                    WrapText();
                    break;

                case TextFormat.Shrink:
                    ScaleText();
                    break;
            }
        }

        /// <summary>
        /// Initialises the dimensions of the text once it has been formatted.
        /// </summary>
        private void InitialiseDimensions()
        {
            Vector2 dimensions = font.MeasureString(displayText);

            Width = (int)(dimensions.X * scale);
            Height = (int)(dimensions.Y * scale);
        }

        /// <summary>
        /// Wraps the text if it exceeds the maximum width.
        /// </summary>
        private void WrapText()
        {
            string[] words = text.Split(' ');

            StringBuilder result = new StringBuilder();
            StringBuilder line = new StringBuilder();

            foreach (string word in words)
            {
                if (font.MeasureString(line).X + font.MeasureString(word).X > maxWidth)
                {
                    result.Append(line);
                    result.Append("\n");

                    line.Clear();
                    line.Append(word);

                    continue;
                }

                if (!string.IsNullOrEmpty(line.ToString()))
                {
                    line.Append(" ");
                }

                line.Append(word);
            }

            if (!string.IsNullOrWhiteSpace(line.ToString()))
            {
                result.Append(line);
            }

            displayText = result.ToString();
        }

        /// <summary>
        /// Adjusts the scale of the text to fit within the maximum width.
        /// </summary>
        private void ScaleText()
        {
            Vector2 dimensions = font.MeasureString(displayText);

            if (dimensions.X > maxWidth)
            {
                scale = maxWidth / dimensions.X;
            }
        }

        #endregion
    }
}
