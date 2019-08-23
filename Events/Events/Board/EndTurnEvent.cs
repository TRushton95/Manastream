namespace EventSystem.Events.Game
{
    public class EndTurnEvent : Event
    {
        public EndTurnEvent()
            : base(EventTypes.Board.EndTurn)
        {
        }
    }
}