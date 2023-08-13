using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Damage
{
    public class EnemyDamageRepositoryImpl : IEnemyDamageRepository
    {
        public EnemyHP GetHp(EnemyStatus status)
        {
            return EnemyHP.Of(status.Hp);
        }

        public void UpdateHp(EnemyStatus status, EnemyHP hp)
        {
            status.Hp = hp.Value;
        }
    }
}