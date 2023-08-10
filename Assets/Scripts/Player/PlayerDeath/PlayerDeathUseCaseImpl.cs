namespace ShootingGame.Player.PlayerDeath
{
    public class PlayerDeathUseCaseImpl : IPlayerDeathUseCase
    {
        public bool Handle(PlayerDeathInputData inputData)
        {
            var gameObject = inputData.GameObject;
            var hp = inputData.Hp;

            if (hp == PlayerHp.Of(0))
            {
                gameObject.SetActive(false);
                return true;
            }
            
            return false;
        }
    }
}