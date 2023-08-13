using Microsoft.Extensions.DependencyInjection;

namespace ShootingGame.Player.Damage
{
    public class PlayerDamageUseCaseImpl : IPlayerDamageUseCase
    {
        private readonly IPlayerDamageRepository _repository;
        
        public PlayerDamageUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IPlayerDamageRepository>();
        }
        
        public void Handle(PlayerDamageInputData inputData)
        {
            Ap ap = inputData.Ap;
            PlayerHp hp = _repository.GetHp();
            _repository.UpdateHp(hp - ap);
        }
    }
}