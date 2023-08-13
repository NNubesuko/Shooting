using ShootingGame.Components.Enemy;
using UnityEngine;

namespace ShootingGame.Enemy.Move
{
    public class EnemyMoveInputData
    {
        internal Vector2 Position { get; }
        internal float DeltaTime { get; }
        internal EnemyStatus Status { get; }

        private EnemyMoveInputData(
            Vector2 position,
            float deltaTime,
            EnemyStatus status)
        {
            Position = position;
            DeltaTime = deltaTime;
            Status = status;
        }

        public static EnemyMoveInputData Of(
            Vector2 position,
            float deltaTime,
            EnemyStatus status)
        {
            return new EnemyMoveInputData(position, deltaTime, status);
        }
    }
}