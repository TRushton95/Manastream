namespace Manastream.Src.EventSystem.Events.Game
{
    public class EndTurnEvent : Event
    {
        public EndTurnEvent()
            : base(EventTypes.Board.EndTurn)
        {
        }
    }
}
