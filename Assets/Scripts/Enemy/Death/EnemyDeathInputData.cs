using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Death
{
    public class EnemyDeathInputData
    {
        internal EnemyStatus Status { get; }

        private EnemyDeathInputData(EnemyStatus status)
        {
            Status = status;
        }

        public static EnemyDeathInputData Of(EnemyStatus status)
        {
            return new EnemyDeathInputData(status);
        }
    }
}