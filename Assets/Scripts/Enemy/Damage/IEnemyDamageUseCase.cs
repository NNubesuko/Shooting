using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Damage
{
    public interface IEnemyDamageUseCase
    {
        void Handle(EnemyDamageInputData inputData);
    }
}