namespace ShootingGame.Player.Damage
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