namespace ShootingGame.Player.DeathPlayer
{
    public interface IDeathPlayerUseCase
    {
        /// <summary>
        /// プレイヤーが死亡しているか判定する
        /// </summary>
        /// <param name="inputData">プレイヤーの死亡判定に使用するデータ群</param>
        /// <returns>死亡していたらtrue 死亡していないならfalse</returns>
        bool Handle(DeathPlayerInputData inputData);
    }
}