namespace Manastream.Src.Gameplay.Entities
{
    public class Player
    {
        private static int MaxMana = 3;

        public Player(int team)
        {
            this.Team = team;
            this.CurrentMana = MaxMana;
        }

        public int Team
        {
            get;
        }

        public int CurrentMana
        {
            get;
            set;
        }
    }
}
