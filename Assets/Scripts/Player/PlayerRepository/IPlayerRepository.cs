using System;

namespace ShootingGame.Player.PlayerRepository
{
    public interface IPlayerRepository
    {
        /// <summary>
        /// プレイヤーの回避速度を取得する
        /// </summary>
        /// <returns>プレイヤーの回避速度</returns>
        PlayerAvoidsSpeed GetAvoidsSpeed();

        /// <summary>
        /// プレイヤーの回避距離を取得する
        /// </summary>
        /// <returns>プレイヤーの回避距離</returns>
        PlayerAvoidsDistance GetAvoidsDistance();

        /// <summary>
        /// プレイヤーが移動可能であるかの判定を取得する
        /// </summary>
        /// <returns>プレイヤーが移動可能であるかの判定</returns>
        bool GetCanMove();

        /// <summary>
        /// プレイヤーが移動可能であるかの判定を更新する
        /// </summary>
        /// <param name="canMove">更新するプレイヤーが移動可能であるかの判定</param>
        void UpdateCanMove(bool canMove);

        /// <summary>
        /// プレイヤーが回避しているかの判定を取得する
        /// </summary>
        /// <returns>プレイヤーが回避しているかの判定</returns>
        bool GetIsAvoiding();
        
        /// <summary>
        /// プレイヤーの回避しているかの判定を更新する
        /// </summary>
        /// <param name="isAvoiding">更新するプレイヤーが回避しているかの判定</param>
        void UpdateIsAvoiding(bool isAvoiding);
    }
}