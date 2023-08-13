using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Attack
{
    public class EnemyAttackRepositoryImpl : IEnemyAttackRepository
    {
        public EnemyAP GetAp(EnemyStatus status)
        {
            return EnemyAP.Of(status.Ap);
        }
    }
}