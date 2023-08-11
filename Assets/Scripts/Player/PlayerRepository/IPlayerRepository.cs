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
        /// プレイヤーの移動速度を取得する
        /// </summary>
        /// <returns>プレイヤーの移動速度</returns>
        PlayerMoveSpeed GetMoveSpeed();

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
    }
}