namespace ShootingGame.Player.DamagePlayerComponent
{
    public class PlayerDamageInputData
    {
        internal PlayerHp Hp { get; }
        internal Ap Ap { get; }

        private PlayerDamageInputData(PlayerHp hp, Ap ap)
        {
            Hp = hp;
            Ap = ap;
        }

        public static PlayerDamageInputData Of(PlayerHp hp, Ap ap)
        {
            return new PlayerDamageInputData(hp, ap);
        }
    }
}