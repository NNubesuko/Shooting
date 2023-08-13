using ShootingGame.Components.Enemy;
using UnityEngine;

namespace ShootingGame.Enemy.Move
{
    public interface IEnemyMoveRepository
    {
        /// <summary>
        /// 敵の移動速度を取得する
        /// </summary>
        /// <param name="status"></param>
        /// <returns>敵の移動速度</returns>
        EnemyMoveSpeed GetMoveSpeed(EnemyStatus status);
        
        /// <summary>
        /// 敵の移動する座標のテーブルを取得する
        /// </summary>
        /// <returns>敵の移動する座標のテーブル</returns>
        Vector2[] GetTargetTable(EnemyStatus status);

        /// <summary>
        /// 現在のテーブルの番号を取得する
        /// </summary>
        /// <returns>現在のテーブルの番号</returns>
        int GetTableIndex(EnemyStatus status);
    }
}