using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Attack
{
    public interface IEnemyAttackRepository
    {
        /// <summary>
        /// 敵の攻撃力を取得する
        /// </summary>
        /// <returns>敵の攻撃力</returns>
        EnemyAP GetAp(EnemyStatus status);
    }
}