using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components;
using ShootingGame.Components.Bullet;

namespace ShootingGame.Bullet.Attack
{
    public class BulletAttackUseCaseImpl : IBulletAttackUseCase
    {
        private readonly IBulletAttackRepository _repository;

        public BulletAttackUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IBulletAttackRepository>();
        }
        
        public void Handle(BulletAttackInputData inputData)
        {
            BulletStatus status = inputData.Status;
            IDamage enemy = inputData.Enemy;
            BulletAP ap = _repository.GetAp(status);
            enemy.Damage(ap);
        }
    }
}