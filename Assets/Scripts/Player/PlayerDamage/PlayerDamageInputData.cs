namespace ShootingGame.Player.DamagePlayerComponent
{
    public class PlayerDamageInputData
    {
        public Ap Ap { get; }

        private PlayerDamageInputData(Ap ap)
        {
            Ap = ap;
        }

        public static PlayerDamageInputData Of(Ap ap)
        {
            return new PlayerDamageInputData(ap);
        }
    }
}