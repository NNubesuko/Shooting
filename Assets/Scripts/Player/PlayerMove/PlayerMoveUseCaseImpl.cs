using KataokaLib.System;
using UnityEngine;

namespace ShootingGame.PlayerMove
{
    public class PlayerMoveUseCaseImpl : IPlayerMoveUseCase
    {
        public Vector2 Handle(PlayerMoveInputData inputData)
        {
            var position = inputData.Position;
            var deltaTime = inputData.DeltaTime;
            var moveSpeed = inputData.MoveSpeed;
            var horizontalMoveRange = inputData.HorizontalMoveRange;
            var verticalMoveRange = inputData.VerticalMoveRange;
            
            Vector2 velocity = position + moveSpeed * Inputk.GetAxis() * deltaTime;

            velocity.x = horizontalMoveRange.WithinRange(velocity.x);
            velocity.y = verticalMoveRange.WithinRange(velocity.y);

            return velocity;
        }
    }
}