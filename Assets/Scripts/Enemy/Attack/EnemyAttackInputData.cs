using ShootingGame.Components;
using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Attack
{
    public class EnemyAttackInputData
    {
        internal EnemyStatus Status { get; }
        internal IDamage Player { get; }

        private EnemyAttackInputData(EnemyStatus status, IDamage player)
        {
            Status = status;
            Player = player;
        }

        public static EnemyAttackInputData Of(EnemyStatus status, IDamage player)
        {
            return new EnemyAttackInputData(status, player);
        }
    }
}