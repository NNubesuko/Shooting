namespace ShootingGame.Player.Death
{
    public interface IPlayerDeathRepository
    {
        /// <summary>
        /// プレイヤーの体力を取得する
        /// </summary>
        /// <returns>プレイヤーの大量</returns>
        PlayerHp GetHp();

        /// <summary>
        /// プレイヤーの死亡判定を更新する
        /// </summary>
        /// <param name="isDeath">更新する死亡判定</param>
        void UpdateIsDeath(bool isDeath);
    }
}