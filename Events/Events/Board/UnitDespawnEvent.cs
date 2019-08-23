namespace EventSystem.Events.Game
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;

    #endregion

    public class UnitDespawnEvent : Event
    {
        public UnitDespawnEvent(Unit unit)
            : base(EventTypes.Board.UnitDespawn)
        {
            this.Unit = unit;
        }

        public Unit Unit
        {
            get;
        }
    }
}