﻿namespace Manastream.Src.UI.Definitions
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.EventSystem.Events;
    using Manastream.Src.EventSystem.Events.Debug;
    using Manastream.Src.EventSystem.Events.Game;
    using Manastream.Src.Gameplay.Enums;
    using Manastream.Src.GameResources;
    using Manastream.Src.UI.Components;
    using Manastream.Src.UI.Components.Complex;
    using Manastream.Src.UI.Enums;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class PlayDefinition
    {
        private static UserInterface ui;
        private static int nextComponentId;
        private static List<HealthBar> healthBars;

        public static UserInterface BuildUI()
        {
            nextComponentId = 0;
            healthBars = new List<HealthBar>();

            ui = new UserInterface();
            ui.Components = BuildComponents();
            AttachListeners();
            
            return ui;
        }

        private static List<UIComponent> BuildComponents()
        {
            List<UIComponent> result = new List<UIComponent>();

            Button button = new Button(nextComponentId++, 200, 50, "End turn", new RelativePositionProfile(HorizontalAlign.Right, VerticalAlign.Bottom, -10, -10), DrawLayer.UI,
                Color.Red, Color.Black, Color.Pink, Color.Black);
            button.OnClickEvent = CreateEndTurnEvent;
            result.Add(button);

            Profile profile = new Profile(nextComponentId++, new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Top, 0, 0), DrawLayer.UI);
            profile.AddEventHandler(EventTypes.Debug.SelectUnit, profile.OnSelectUnit);
            result.Add(profile);

            return result;
        }

        private static void AttachListeners()
        {
            ui.AddEventHandler(EventTypes.Game.UnitSpawn, OnUnitSpawn);
            ui.AddEventHandler(EventTypes.Game.UnitDespawn, OnUnitDespawn);
        }

        #region Component Delegates

        private static Event CreateEndTurnEvent()
        {
            return new EndTurnEvent();
        }

        #endregion

        #region Event Handlers

        private static void OnUnitSpawn(Event e)
        {
            UnitSpawnEvent args = (UnitSpawnEvent)e;

            if (args.Unit == null)
            {
                return;
            }

            HealthBar healthBar = new HealthBar(nextComponentId++, 75, 10, new AbsolutePositionProfile(args.Unit.CanvasPosition, 0, 15), DrawLayer.Game, args.Unit);
            healthBar.Initialise(Resources.GetInstance().GraphicsDevice.Viewport.Bounds);
            ui.Components.Add(healthBar);
            healthBars.Add(healthBar);
        }

        private static void OnUnitDespawn(Event e)
        {
            UnitDespawnEvent args = (UnitDespawnEvent)e;

            HealthBar healthBar = healthBars.SingleOrDefault(bar => bar.Unit.Id == args.Unit.Id);
            ui.Components.Remove(healthBar);
            healthBars.Remove(healthBar);
        }

        #endregion
    }
}
