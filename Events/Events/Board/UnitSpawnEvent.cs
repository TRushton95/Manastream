namespace EventSystem.Events.Game
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;

    #endregion

    public class UnitSpawnEvent : Event
    {
        public UnitSpawnEvent(Unit unit)
            : base(EventTypes.Board.UnitSpawn)
        {
            this.Unit = unit;
        }

        public Unit Unit
        {
            get;
        }
    }
}