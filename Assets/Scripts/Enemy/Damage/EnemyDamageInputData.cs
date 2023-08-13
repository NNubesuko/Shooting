using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Damage
{
    public class EnemyDamageInputData
    {
        internal EnemyStatus Status { get; }
        internal Ap Ap { get; }

        private EnemyDamageInputData(EnemyStatus status, Ap ap)
        {
            Status = status;
            Ap = ap;
        }

        public static EnemyDamageInputData Of(EnemyStatus status, Ap ap)
        {
            return new EnemyDamageInputData(status, ap);
        }
    }
}