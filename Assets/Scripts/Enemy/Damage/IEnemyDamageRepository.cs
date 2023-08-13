using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Damage
{
    public interface IEnemyDamageRepository
    {
        /// <summary>
        /// 敵の体力を取得する
        /// </summary>
        /// <returns>敵の体力</returns>
        EnemyHP GetHp(EnemyStatus status);

        /// <summary>
        /// 敵の体力を更新する
        /// </summary>
        /// <param name="hp">更新する敵の体力</param>
        void UpdateHp(EnemyStatus status, EnemyHP hp);
    }
}