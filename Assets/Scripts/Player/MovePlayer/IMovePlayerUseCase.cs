using UnityEngine;

namespace ShootingGame.MovePlayer
{
    public interface IMovePlayerUseCase
    {
        /// <summary>
        /// プレイヤーを移動させる
        /// </summary>
        /// <param name="inputData">プレイヤーを移動させる際に使用するデータ群</param>
        /// <returns>更新された座標が返される</returns>
        Vector2 Handle(MovePlayerInputData inputData);
    }
}