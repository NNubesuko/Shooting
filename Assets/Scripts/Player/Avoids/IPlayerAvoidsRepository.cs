namespace ShootingGame.Player.Avoids
{
    public interface IPlayerAvoidsRepository
    {
        /// <summary>
        /// プレイヤーのスタミナを取得する
        /// </summary>
        /// <returns>プレイヤーのスタミナ</returns>
        PlayerStamina GetStamina();

        /// <summary>
        /// プレイヤーのスタミナ消費量を取得する
        /// </summary>
        /// <returns>プレイヤーのスタミナ消費量</returns>
        PlayerStamina GetConsumptionStamina();

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
        /// プレイヤーが回避しているかの判定を取得する
        /// </summary>
        /// <returns>プレイヤーが回避しているかの判定</returns>
        bool GetIsAvoiding();
        
        /// <summary>
        /// プレイヤーが移動可能であるかの判定を更新する
        /// </summary>
        /// <param name="canMove">更新するプレイヤーが移動可能であるかの判定</param>
        void UpdateCanMove(bool canMove);

        /// <summary>
        /// プレイヤーのスタミナを更新する
        /// </summary>
        /// <param name="stamina">更新するプレイヤーのスタミナ</param>
        void UpdateStamina(PlayerStamina stamina);
        
        /// <summary>
        /// プレイヤーの回避しているかの判定を更新する
        /// </summary>
        /// <param name="isAvoiding">更新するプレイヤーが回避しているかの判定</param>
        void UpdateIsAvoiding(bool isAvoiding);
    }
}