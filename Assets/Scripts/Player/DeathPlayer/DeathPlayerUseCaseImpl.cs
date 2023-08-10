namespace ShootingGame.Player.DeathPlayer
{
    public class DeathPlayerUseCaseImpl : IDeathPlayerUseCase
    {
        public bool Handle(DeathPlayerInputData inputData)
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