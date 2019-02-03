﻿namespace Manastream.Src.UI.Definitions
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.EventSystem.Events;
    using Manastream.Src.EventSystem.Events.Game;
    using Manastream.Src.UI.Components;
    using Manastream.Src.UI.Components.Complex;
    using Manastream.Src.UI.Enums;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    #endregion

    public class PlayDefinition
    {
        public static UserInterface BuildUI()
        {
            List<UIComponent> components = new List<UIComponent>();
            
            Button button = new Button(200, 50, "End turn", new RelativePositionProfile(HorizontalAlign.Right, VerticalAlign.Bottom, -10, -10),
                Color.Red, Color.Black, Color.Pink, Color.Black);
            button.OnClickEvent = CreateEndTurnEvent;
            components.Add(button);

            Profile profile = new Profile(new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Top, 0, 0));
            profile.AddEventHandler(EventTypes.Debug.SelectUnit, profile.OnSelectUnit);
            components.Add(profile);

            UserInterface result = new UserInterface();
            result.Components = components;

            return result;
        }

        private static Event CreateEndTurnEvent()
        {
            return new EndTurnEvent();
        }
    }
}
