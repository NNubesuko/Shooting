using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components.Enemy;

namespace ShootingGame.Enemy.Death
{
    public class EnemyDeathUseCaseImpl : IEnemyDeathUseCase
    {
        private readonly IEnemyDeathRepository _repository;

        public EnemyDeathUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IEnemyDeathRepository>();
        }
        
        public bool Handle(EnemyDeathInputData inputData)
        {
            EnemyStatus status = inputData.Status;
            EnemyHP hp = _repository.GetHp(status);

            if (hp == EnemyHP.Of(0))
            {
                _repository.UpdateIsDeath(status, true);
                return true;
            }

            return false;
        }
    }
}