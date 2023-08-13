namespace ShootingGame.Enemy.Attack
{
    public interface IEnemyAttackUseCase
    {
        void Handle(EnemyAttackInputData inputData);
    }
}