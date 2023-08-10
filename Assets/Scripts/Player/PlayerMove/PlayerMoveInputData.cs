using UnityEngine;

namespace ShootingGame.PlayerMove
{
    public class PlayerMoveInputData
    {
        internal Vector2 Position { get; }
        internal float DeltaTime { get; }
        internal PlayerMoveSpeed MoveSpeed { get; }
        internal PlayerHorizontalMoveRange HorizontalMoveRange { get; }
        internal PlayerVerticalMoveRange VerticalMoveRange { get; }

        private PlayerMoveInputData(
            Vector2 position,
            float deltaTime,
            PlayerMoveSpeed moveSpeed,
            PlayerHorizontalMoveRange horizontalMoveRange,
            PlayerVerticalMoveRange verticalMoveRange)
        {
            Position = position;
            DeltaTime = deltaTime;
            MoveSpeed = moveSpeed;
            HorizontalMoveRange = horizontalMoveRange;
            VerticalMoveRange = verticalMoveRange;
        }

        public static PlayerMoveInputData Of(
            Vector2 position,
            float deltaTime,
            PlayerMoveSpeed moveSpeed,
            PlayerHorizontalMoveRange horizontalMoveRange,
            PlayerVerticalMoveRange verticalMoveRange)
        {
            return new PlayerMoveInputData(position, deltaTime, moveSpeed, horizontalMoveRange, verticalMoveRange);
        }
    }
}