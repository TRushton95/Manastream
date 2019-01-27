namespace Manastream.Src.UI.Definitions
{
    #region Usings

    using Manastream.Src.EventSystem.Events;
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

            Button button = new Button(200, 50, "End turn", new RelativePositionProfile(HorizontalAlign.Center, VerticalAlign.Top, 0, 10),
                Color.Red, Color.Black, Color.Pink, Color.Black);
            button.OnClickEvent = GetEndTurnEvent;
            result.Add(button);

            return result;
        }

        private static Event GetEndTurnEvent()
        {
            return new EndTurnEvent();
        }
    }
}
