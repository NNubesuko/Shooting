namespace ShootingGame.Player.DamagePlayerComponent
{
    public class PlayerDamageUseCaseImpl : IPlayerDamageUseCase
    {
        public PlayerHp Handle(PlayerDamageInputData inputData)
        {
            var ap = inputData.Ap;
            var hp = inputData.Hp;

            return hp - ap;
        }
    }
}