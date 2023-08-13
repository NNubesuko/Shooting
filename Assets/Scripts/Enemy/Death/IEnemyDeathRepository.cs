using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Death
{
    public interface IEnemyDeathRepository
    {
        /// <summary>
        /// 敵の体力を取得する
        /// </summary>
        /// <returns>敵の体力</returns>
        EnemyHP GetHp(EnemyStatus status);

        /// <summary>
        /// 敵の死亡判定を更新する
        /// </summary>
        /// <param name="isDeath">更新する敵の死亡判定</param>
        void UpdateIsDeath(EnemyStatus status, bool isDeath);
    }
}