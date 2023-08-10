using UnityEngine;

namespace ShootingGame.PlayerMove
{
    public interface IPlayerMoveUseCase
    {
        /// <summary>
        /// プレイヤーを移動させる
        /// </summary>
        /// <param name="inputData">プレイヤーを移動させる際に使用するデータ群</param>
        /// <returns>更新された座標が返される</returns>
        Vector2 Handle(PlayerMoveInputData inputData);
    }
}