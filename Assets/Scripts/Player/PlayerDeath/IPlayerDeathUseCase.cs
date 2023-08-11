namespace ShootingGame.Player.PlayerDeath
{
    public interface IPlayerDeathUseCase
    {
        /// <summary>
        /// プレイヤーが死亡しているか判定する
        /// </summary>
        /// <param name="inputData">プレイヤーの死亡判定に使用するデータ群</param>
        /// <returns>死亡していたらtrue 死亡していないならfalse</returns>
        void Handle(PlayerDeathInputData inputData);
    }
}