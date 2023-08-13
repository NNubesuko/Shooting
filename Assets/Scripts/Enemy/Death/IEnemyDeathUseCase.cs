namespace ShootingGame.Enemy.Death
{
    public interface IEnemyDeathUseCase
    {
        bool Handle(EnemyDeathInputData inputData);
    }
}