using System;

namespace ShootingGame.Player.PlayerRepository
{
    public interface IPlayerRepository
    {
        /// <summary>
        /// プレイヤーの体力を取得する
        /// </summary>
        /// <returns>プレイヤーの大量</returns>
        PlayerHp GetHp();

        /// <summary>
        /// プレイヤーのスタミナを取得する
        /// </summary>
        /// <returns>プレイヤーのスタミナ</returns>
        PlayerStamina GetStamina();

        /// <summary>
        /// プレイヤーの一定時間に回復するスタミナを取得する
        /// </summary>
        /// <returns>プレイヤーの一定時間に回復するスタミナ</returns>
        PlayerStamina GetHealStamina();

        /// <summary>
        /// プレイヤーのスタミナが回復する間隔を取得する
        /// </summary>
        /// <returns>プレイヤーのスタミナが回復する間隔</returns>
        TimeSpan GetHealStaminaInterval();

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
        /// プレイヤーの横の移動可能範囲を取得する
        /// </summary>
        /// <returns>プレイヤーの横の移動可能範囲</returns>
        PlayerHorizontalMoveRange GetHorizontalMoveRange();
        
        /// <summary>
        /// プレイヤーの縦の移動可能範囲を取得する
        /// </summary>
        /// <returns>プレイヤーの縦の移動可能範囲</returns>
        PlayerVerticalMoveRange GetVerticalMoveRange();

        /// <summary>
        /// プレイヤーの体力を更新する
        /// </summary>
        /// <param name="hp">更新するプレイヤーの体力</param>
        void UpdateHp(PlayerHp hp);

        /// <summary>
        /// プレイヤーのスタミナを更新する
        /// </summary>
        /// <param name="stamina">更新するプレイヤーのスタミナ</param>
        void UpdateStamina(PlayerStamina stamina);

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