using System;

namespace ShootingGame.Player.HealStamina
{
    public interface IPlayerHealStaminaRepository
    {
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
        /// プレイヤーのスタミナを更新する
        /// </summary>
        /// <param name="stamina">更新するプレイヤーのスタミナ</param>
        void UpdateStamina(PlayerStamina stamina);
    }
}