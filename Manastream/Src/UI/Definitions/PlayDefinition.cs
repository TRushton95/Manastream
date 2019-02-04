namespace Manastream.Src.UI.Definitions
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

    #endregion

    public class PlayDefinition
    {
        private static UserInterface ui;

        public static UserInterface BuildUI()
        {
            ui = new UserInterface();
            ui.Components = BuildComponents();
            AttachListeners();
            
            return ui;
        }

        private static List<UIComponent> BuildComponents()
        {
            List<UIComponent> result = new List<UIComponent>();

            Button button = new Button(200, 50, "End turn", new RelativePositionProfile(HorizontalAlign.Right, VerticalAlign.Bottom, -10, -10), DrawLayer.UI,
                Color.Red, Color.Black, Color.Pink, Color.Black);
            button.OnClickEvent = CreateEndTurnEvent;
            result.Add(button);

            Profile profile = new Profile(new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Top, 0, 0), DrawLayer.UI);
            profile.AddEventHandler(EventTypes.Debug.SelectUnit, profile.OnSelectUnit);
            result.Add(profile);

            return result;
        }

        private static void AttachListeners()
        {
            ui.AddEventHandler(EventTypes.Game.UnitSpawn, OnUnitSpawn);
        }

        private static Event CreateEndTurnEvent()
        {
            return new EndTurnEvent();
        }

        private static void OnUnitSpawn(Event e)
        {
            UnitSpawnEvent args = (UnitSpawnEvent)e;

            if (args.Unit == null)
            {
                return;
            }

            HealthBar healthBar = new HealthBar(75, 10, new AbsolutePositionProfile(args.Unit.CanvasPosition, 0, 15), DrawLayer.Game, args.Unit);
            healthBar.Initialise(Resources.GetInstance().GraphicsDevice.Viewport.Bounds);
            ui.Components.Add(healthBar);
        }
    }
}
