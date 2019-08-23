namespace EventSystem.Events.Game
{
    public class UnitDespawnEvent : Event
    {
        public UnitDespawnEvent(int unitId)
            : base(EventTypes.Board.UnitDespawn)
        {
            this.UnitId = unitId;
        }

        public int UnitId
        {
            get;
        }
    }
}