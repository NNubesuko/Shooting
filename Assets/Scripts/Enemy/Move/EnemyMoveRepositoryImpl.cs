using ShootingGame.Components.Enemy;
using UnityEngine;

namespace ShootingGame.Enemy.Move
{
    public class EnemyMoveRepositoryImpl : IEnemyMoveRepository
    {
        public EnemyMoveSpeed GetMoveSpeed(EnemyStatus status)
        {
            return EnemyMoveSpeed.Of(status.MoveSpeed);
        }
        
        public Vector2[] GetTargetTable(EnemyStatus status)
        {
            return status.TargetTable;
        }

        public int GetTableIndex(EnemyStatus status)
        {
            return status.TableIndex;
        }
    }
}