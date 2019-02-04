namespace Manastream.Src.Gameplay.Graphics
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.EventSystem.Events;
    using Manastream.Src.EventSystem.Events.Graphics;
    using Manastream.Src.Gameplay.Enums;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The drawing manager class that is responsible for recieving DrawReady events and rendering the textures.
    /// </summary>
    public class DrawingManager : Listener
    {
        #region Fields

        private static DrawingManager instance;
        private Dictionary<DrawLayer, SpriteBatch> spriteBatchLookup;

        #endregion

        private DrawingManager()
        {
            spriteBatchLookup = new Dictionary<DrawLayer, SpriteBatch>();
            InitialiseEventHandlers();
        }

        #region Properties
        
        public static DrawingManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DrawingManager();
                }

                return instance;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Register a new spritebatch to a draw layer enum.
        /// </summary>
        public void RegisterSpriteBatch(DrawLayer drawLayer, SpriteBatch spriteBatch)
        {
            bool drawLayerRegistered = spriteBatchLookup.ContainsKey(drawLayer);

            if (drawLayerRegistered)
            {
                Console.WriteLine($"SpriteBatch already registered to DrawLayer: {drawLayer}");
                return;
            }

            spriteBatchLookup.Add(drawLayer, spriteBatch);
        }

        /// <summary>
        /// Unregister a spritebatch.
        /// </summary>
        public void UnregisterSpriteBatch(DrawLayer drawLayer)
        {
            spriteBatchLookup.Remove(drawLayer);
        }

        /// <summary>
        /// The texture draw ready event handler.
        /// </summary>
        private void OnTextureDrawReady(Event e)
        {
            TextureDrawReadyEvent args = (TextureDrawReadyEvent)e;

            SpriteBatch sb;
            spriteBatchLookup.TryGetValue(args.DrawLayer, out sb);

            if (args.SourceRectangle == Rectangle.Empty)
            {
                sb.Draw(args.Texture, args.Position, Color.White);
            }
            else
            {
                sb.Draw(args.Texture, args.Position, args.SourceRectangle, Color.White);
            }
        }

        /// <summary>
        /// The string draw ready event handler.
        /// </summary>
        private void OnStringDrawReady(Event e)
        {
            StringDrawReadyEvent args = (StringDrawReadyEvent)e;

            SpriteBatch sb;
            spriteBatchLookup.TryGetValue(args.DrawLayer, out sb);

            sb.DrawString(args.Font, args.Text, args.Position, args.Colour, 0, Vector2.Zero, args.Scale, SpriteEffects.None, 0);
        }

        /// <summary>
        /// Initialises the event handlers.
        /// </summary>
        private void InitialiseEventHandlers()
        {
            AddEventHandler(EventTypes.Graphics.TextureDrawReady, OnTextureDrawReady);
            AddEventHandler(EventTypes.Graphics.StringDrawReady, OnStringDrawReady);
        }

        #endregion
    }
}
