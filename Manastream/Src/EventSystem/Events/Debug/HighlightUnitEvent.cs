namespace Manastream.Src.EventSystem.Events.Debug
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;

    #endregion

    public class HighlightUnitEvent : Event
    {
        public HighlightUnitEvent(Unit highlightedUnit)
            : base(EventTypes.Debug.HighlightUnit)
        {
            this.HighlightedUnit = highlightedUnit;
        }

        public Unit HighlightedUnit
        {
            get;
        }
    }
}
