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
    }
}