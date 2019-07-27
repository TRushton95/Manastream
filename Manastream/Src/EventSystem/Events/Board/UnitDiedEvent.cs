namespace Manastream.Src.EventSystem.Events.Game
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;

    #endregion

    public class UnitDiedEvent : Event
    {
        public UnitDiedEvent(Unit unit)
            : base(EventTypes.Board.UnitDied)
        {
            this.Unit = unit;
        }

        public Unit Unit
        {
            get;
        }
    }
}
