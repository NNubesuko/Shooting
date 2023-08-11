using KataokaLib.System;
using UnityEngine;

namespace ShootingGame.Player.PlayerAvoids
{
    public class PlayerAvoidsUseCaseImpl : IPlayerAvoidsUseCase
    {
        private Vector2 _target;
        private bool isAvoiding = false;
        
        public (Vector2, bool) Handle(PlayerAvoidsInputData inputData)
        {
            var position = inputData.Position;
            var deltaTime = inputData.DeltaTime;
            var avoidsSpeed = inputData.AvoidsSpeed;
            var avoidsDistance = inputData.AvoidsDistance;
            
            // 回避の入力があり
            // 移動していて
            // 回避していない状態であれば、回避する
            if (Inputk.GetKeyDown(KeyCode.Space) && Inputk.IsMoving() && !isAvoiding)
            {
                _target = position + avoidsDistance * Inputk.GetAxis();
                isAvoiding = true;
            }

            // 回避後の座標に到着したら回避を終了する
            if (position == _target)
            {
                isAvoiding = false;
            }

            // 回避処理
            if (isAvoiding)
            {
                var updatePosition = Vector2.MoveTowards(position, _target, avoidsSpeed * deltaTime);
                return (updatePosition, isAvoiding);
            }

            return (position, isAvoiding);
        }
    }
}