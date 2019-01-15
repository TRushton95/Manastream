namespace Manastream.Src.EventSystem.Events.Debug
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;

    #endregion

    public class SelectUnitEvent : Event
    {
        public SelectUnitEvent(Unit selectedUnit)
            : base(EventTypes.Debug.SelectUnit)
        {
            this.SelectedUnit = selectedUnit;
        }

        public Unit SelectedUnit
        {
            get;
        }
    }
}
