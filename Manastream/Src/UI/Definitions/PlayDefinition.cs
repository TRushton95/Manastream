namespace Manastream.Src.UI.Definitions
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.EventSystem.Events;
    using Manastream.Src.EventSystem.Events.Debug;
    using Manastream.Src.EventSystem.Events.Game;
    using Manastream.Src.UI.Components.Complex;
    using Manastream.Src.UI.Enums;
    using Manastream.Src.UI.PositionProfiles;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    #endregion

    public class PlayDefinition
    {
        public static List<ComplexUIComponent> BuildUI()
        {
            List<ComplexUIComponent> result = new List<ComplexUIComponent>();
            
            Button button = new Button(200, 50, "End turn", new RelativePositionProfile(HorizontalAlign.Right, VerticalAlign.Bottom, -10, -10),
                Color.Red, Color.Black, Color.Pink, Color.Black);
            button.OnClickEvent = CreateEndTurnEvent;
            result.Add(button);

            Profile profile = new Profile(string.Empty, 0, 0, 0, 0, new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Top, 0, 0));
            result.Add(profile);

            return result;
        }

        private static Event CreateEndTurnEvent()
        {
            return new EndTurnEvent();
        }
    }
}
