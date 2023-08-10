using UnityEngine;

namespace ShootingGame.MovePlayer
{
    public class MovePlayerInputData
    {
        internal Vector2 Position { get; }
        internal PlayerMoveSpeed MoveSpeed { get; }
        internal PlayerHorizontalMoveRange HorizontalMoveRange { get; }
        internal PlayerVerticalMoveRange VerticalMoveRange { get; }

        private MovePlayerInputData(
            Vector2 position,
            PlayerMoveSpeed moveSpeed,
            PlayerHorizontalMoveRange horizontalMoveRange,
            PlayerVerticalMoveRange verticalMoveRange)
        {
            Position = position;
            MoveSpeed = moveSpeed;
            HorizontalMoveRange = horizontalMoveRange;
            VerticalMoveRange = verticalMoveRange;
        }

        public static MovePlayerInputData Of(
            Vector2 position,
            PlayerMoveSpeed moveSpeed,
            PlayerHorizontalMoveRange horizontalMoveRange,
            PlayerVerticalMoveRange verticalMoveRange)
        {
            return new MovePlayerInputData(position, moveSpeed, horizontalMoveRange, verticalMoveRange);
        }
    }
}