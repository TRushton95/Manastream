namespace Manastream.Src.EventSystem.Events.Game
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;

    #endregion

    public class UnitSpawnEvent : Event
    {
        public UnitSpawnEvent(Unit unit)
            : base(EventTypes.Game.UnitSpawn)
        {
            this.Unit = unit;
        }

        public Unit Unit
        {
            get;
        }
    }
}
