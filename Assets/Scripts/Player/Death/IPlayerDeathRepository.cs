namespace ShootingGame.Player.Death
{
    public interface IPlayerDeathRepository
    {
        /// <summary>
        /// プレイヤーの体力を取得する
        /// </summary>
        /// <returns>プレイヤーの大量</returns>
        PlayerHp GetHp();
    }
}