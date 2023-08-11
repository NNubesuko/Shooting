namespace ShootingGame.Player.PlayerDeath
{
    public interface IPlayerDeathUseCase
    {
        /// <summary>
        /// プレイヤーが死亡しているか判定する
        /// </summary>
        /// <returns>死亡していたらtrue 死亡していないならfalse</returns>
        bool Handle();
    }
}