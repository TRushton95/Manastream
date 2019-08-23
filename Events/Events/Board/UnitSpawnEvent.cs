namespace EventSystem.Events.Game
{
    public class UnitSpawnEvent : Event
    {
        public UnitSpawnEvent(int unitId)
            : base(EventTypes.Board.UnitSpawn)
        {
            this.UnitId = unitId;
        }

        public int UnitId
        {
            get;
        }
    }
}