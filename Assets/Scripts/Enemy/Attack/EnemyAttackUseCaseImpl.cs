using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Attack
{
    public class EnemyAttackUseCaseImpl : IEnemyAttackUseCase
    {
        private readonly IEnemyAttackRepository _repository;

        public EnemyAttackUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IEnemyAttackRepository>();
        }
        
        public void Handle(EnemyAttackInputData inputData)
        {
            EnemyStatus status = inputData.Status;
            EnemyAP ap = _repository.GetAp(status);
            inputData.Player.Damage(ap);
        }
    }
}