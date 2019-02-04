namespace Manastream.Src.EventSystem.Events.Game
{
    #region Usings

    using Manastream.Src.Gameplay.Entities.Actors;

    #endregion

    public class UnitDamagedEvent : Event
    {
        public UnitDamagedEvent(Unit caster, Unit unitDamage, int damage)
            : base(EventTypes.Game.UnitDamaged)
        {
            this.Caster = caster;
            this.UnitDamaged = unitDamage;
            this.Damage = damage;
        }

        public Unit Caster
        {
            get;
        }

        public Unit UnitDamaged
        {
            get;
        }

        public int Damage
        {
            get;
        }
    }
}
