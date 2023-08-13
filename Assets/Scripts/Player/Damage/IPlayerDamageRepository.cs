namespace ShootingGame.Player.Damage
{
    public interface IPlayerDamageRepository
    {
        /// <summary>
        /// プレイヤーの体力を取得する
        /// </summary>
        /// <returns>プレイヤーの大量</returns>
        PlayerHp GetHp();

        /// <summary>
        /// プレイヤーの体力を更新する
        /// </summary>
        /// <param name="hp">更新するプレイヤーの体力</param>
        void UpdateHp(PlayerHp hp);
    }
}