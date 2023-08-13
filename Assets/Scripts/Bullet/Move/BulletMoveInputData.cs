using ShootingGame.Components.Bullet;
using UnityEngine;

namespace ShootingGame.Bullet.Move
{
    public class BulletMoveInputData
    {
        internal BulletStatus Status { get; }
        internal Vector2 Position { get; }
        internal float DeltaTime { get; }

        private BulletMoveInputData(
            BulletStatus status,
            Vector2 position,
            float deltaTime)
        {
            Status = status;
            Position = position;
            DeltaTime = deltaTime;
        }

        public static BulletMoveInputData Of(
            BulletStatus status,
            Vector2 position,
            float deltaTime)
        {
            return new BulletMoveInputData(status, position, deltaTime);
        }
    }
}