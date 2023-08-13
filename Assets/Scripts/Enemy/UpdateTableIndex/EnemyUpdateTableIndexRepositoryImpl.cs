using System;
using ShootingGame.Components.Enemy;
using UnityEngine;

namespace ShootingGame.Enemy.UpdateTableIndex
{
    public class EnemyUpdateTableIndexRepositoryImpl : IEnemyUpdateTableIndexRepository
    {
        public TimeSpan GetUpdateTableIndexInterval(EnemyStatus status)
        {
            return TimeSpan.FromSeconds(status.UpdateTableIndexInterval);
        }
        
        public Vector2[] GetTargetTable(EnemyStatus status)
        {
            return status.TargetTable;
        }

        public int GetTableIndex(EnemyStatus status)
        {
            return status.TableIndex;
        }

        public void UpdateTableIndex(EnemyStatus status, int tableIndex)
        {
            status.TableIndex = tableIndex;
        }
    }
}