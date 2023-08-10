using KataokaLib.System;
using UnityEngine;

namespace ShootingGame.Player.PlayerAvoids
{
    public class PlayerAvoidsUseCaseImpl : IPlayerAvoidsUseCase
    {
        public Vector2 Handle(PlayerAvoidsInputData inputData)
        {
            var position = inputData.Position;
            var deltaTime = inputData.DeltaTime;
            var avoidsSpeed = inputData.AvoidsSpeed;
            var avoidsDistance = inputData.AvoidsDistance;
            
            var target = position + avoidsDistance * Inputk.GetAxis();
            return Vector2.MoveTowards(position, target, avoidsSpeed * deltaTime);
        }
    }
}