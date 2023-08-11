using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components.Player;
using ShootingGame.Player.PlayerRepository;

namespace ShootingGame.Player.DamagePlayerComponent
{
    public class PlayerDamageUseCaseImpl : IPlayerDamageUseCase
    {
        private readonly IPlayerRepository _repository;

        public PlayerDamageUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IPlayerRepository>();
        }
        
        public void Handle(PlayerDamageInputData inputData)
        {
            Ap ap = inputData.Ap;
            PlayerHp hp = _repository.GetHp();
            _repository.UpdateHp(hp - ap);
        }
    }
}