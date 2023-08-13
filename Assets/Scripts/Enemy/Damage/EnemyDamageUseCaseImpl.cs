using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Damage
{
    public class EnemyDamageUseCaseImpl : IEnemyDamageUseCase
    {
        private readonly IEnemyDamageRepository _repository;

        public EnemyDamageUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IEnemyDamageRepository>();
        }
        
        public void Handle(EnemyDamageInputData inputData)
        {
            EnemyStatus status = inputData.Status;
            Ap ap = inputData.Ap;
            EnemyHP hp = _repository.GetHp(status);
            _repository.UpdateHp(status, hp - ap);
        }
    }
}