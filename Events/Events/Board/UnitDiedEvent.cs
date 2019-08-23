namespace EventSystem.Events.Game
{
    public class UnitDiedEvent : Event
    {
        public UnitDiedEvent(int unitId)
            : base(EventTypes.Board.UnitDied)
        {
            this.UnitId = unitId;
        }

        public int UnitId
        {
            get;
        }
    }
}