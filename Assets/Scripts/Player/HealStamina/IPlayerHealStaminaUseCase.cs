namespace ShootingGame.Player.HealStamina
{
    public interface IPlayerHealStaminaUseCase
    {
        /// <summary>
        /// プレイヤーのスタミナを一定の間隔で回復する
        /// </summary>
        void Handle(PlayerHealStaminaInputData inputData);
    }
}