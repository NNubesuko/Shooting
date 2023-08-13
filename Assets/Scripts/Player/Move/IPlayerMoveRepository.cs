namespace ShootingGame.Player.Move
{
    public interface IPlayerMoveRepository
    {
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
        /// プレイヤーが移動可能であるかの判定を取得する
        /// </summary>
        /// <returns>プレイヤーが移動可能であるかの判定</returns>
        bool GetCanMove();
    }
}