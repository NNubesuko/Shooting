using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.UpdateTableIndex
{
    public class EnemyUpdateTableIndexInputData
    {
        internal EnemyComponent EnemyComponent { get; }
        internal EnemyStatus Status { get; }

        private EnemyUpdateTableIndexInputData(EnemyComponent enemyComponent, EnemyStatus status)
        {
            EnemyComponent = enemyComponent;
            Status = status;
        }

        public static EnemyUpdateTableIndexInputData Of(EnemyComponent enemyComponent, EnemyStatus status)
        {
            return new EnemyUpdateTableIndexInputData(enemyComponent, status);
        }
    }
}