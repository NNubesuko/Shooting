using KataokaLib.System;
using UnityEngine;

namespace ShootingGame.MovePlayer
{
    public class MovePlayerUseCaseImpl : IMovePlayerUseCase
    {
        public Vector2 Handle(MovePlayerInputData inputData)
        {
            var position = inputData.Position;
            var moveSpeed = inputData.MoveSpeed;
            var horizontalMoveRange = inputData.HorizontalMoveRange;
            var verticalMoveRange = inputData.VerticalMoveRange;
            
            Vector2 velocity = position + moveSpeed * Inputk.GetAxis() * Time.deltaTime;

            velocity.x = horizontalMoveRange.WithinRange(velocity.x);
            velocity.y = verticalMoveRange.WithinRange(velocity.y);

            return velocity;
        }
    }
}