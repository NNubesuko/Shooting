using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Death
{
    public class EnemyDeathRepositoryImpl : IEnemyDeathRepository
    {
        public EnemyHP GetHp(EnemyStatus status)
        {
            return EnemyHP.Of(status.Hp);
        }

        public void UpdateIsDeath(EnemyStatus status, bool isDeath)
        {
            status.IsDeath = isDeath;
        }
    }
}