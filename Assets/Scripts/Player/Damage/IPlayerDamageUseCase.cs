namespace ShootingGame.Player.Damage
{
    public interface IPlayerDamageUseCase
    {
        /// <summary>
        /// プレイヤーにダメージを与える
        /// </summary>
        /// <param name="inputData">プレイヤーにダメージを与える際に使用するデータ群</param>
        /// <returns>更新されたプレイヤーの体力が返される</returns>
        void Handle(PlayerDamageInputData inputData);
    }
}