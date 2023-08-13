namespace ShootingGame.Player.Move
{
    public interface IPlayerMoveRepository
    {
        /// <summary>
        /// プレイヤーの移動速度を取得する
        /// </summary>
        /// <returns>プレイヤーの移動速度</returns>
        PlayerMoveSpeed GetMoveSpeed();
    }
}