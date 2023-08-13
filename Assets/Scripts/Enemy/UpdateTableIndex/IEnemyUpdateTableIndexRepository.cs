using System;
using ShootingGame.Components.Enemy;
using UnityEngine;

namespace ShootingGame.Enemy.UpdateTableIndex
{
    public interface IEnemyUpdateTableIndexRepository
    {
        TimeSpan GetUpdateTableIndexInterval(EnemyStatus status);
        
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

        /// <summary>
        /// 現在のテーブル番号を更新する
        /// </summary>
        /// <param name="status">更新するテーブル番号</param>
        void UpdateTableIndex(EnemyStatus status, int tableIndex);
    }
}