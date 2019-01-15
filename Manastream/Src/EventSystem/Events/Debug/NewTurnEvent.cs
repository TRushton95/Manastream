namespace Manastream.Src.EventSystem.Events.Debug
{
    public class NewTurnEvent : Event
    {
        public NewTurnEvent(int turn)
            : base(EventTypes.Debug.NewTurn)
        {
            this.Turn = turn;
        }

        public int Turn
        {
            get;
        }
    }
}
