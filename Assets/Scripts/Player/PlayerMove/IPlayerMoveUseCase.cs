using UnityEngine;

namespace ShootingGame.PlayerMove
{
    public interface IPlayerMoveUseCase
    {
        /// <summary>
        /// プレイヤーを移動させる
        /// </summary>
        /// <returns>更新された座標が返される</returns>
        Vector2 Handle(PlayerMoveInputData inputData);
    }
}