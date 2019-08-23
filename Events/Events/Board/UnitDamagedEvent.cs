namespace EventSystem.Events.Game
{
    public class UnitDamagedEvent : Event
    {
        public UnitDamagedEvent(int casterId, int unitDamageId, int damage)
            : base(EventTypes.Board.UnitDamaged)
        {
            this.CasterId = casterId;
            this.UnitDamagedId = unitDamageId;
            this.Damage = damage;
        }

        public int CasterId
        {
            get;
        }

        public int UnitDamagedId
        {
            get;
        }

        public int Damage
        {
            get;
        }
    }
}