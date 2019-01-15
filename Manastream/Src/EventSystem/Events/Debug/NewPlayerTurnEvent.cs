namespace Manastream.Src.EventSystem.Events.Debug
{
    #region Usings

    using Manastream.Src.Gameplay.Entities;

    #endregion

    public class NewPlayerTurnEvent : Event
    {
        public NewPlayerTurnEvent(Player player)
            : base(EventTypes.Debug.NewPlayerTurn)
        {
            this.Player = player;
        }

        public Player Player
        {
            get;
        }
    }
}
