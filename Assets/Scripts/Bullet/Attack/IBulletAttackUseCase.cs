namespace ShootingGame.Bullet.Attack
{
    public interface IBulletAttackUseCase
    {
        void Handle(BulletAttackInputData inputData);
    }
}