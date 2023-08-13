using Microsoft.Extensions.DependencyInjection;

namespace ShootingGame.Player.Death
{
    public class PlayerDeathUseCaseImpl : IPlayerDeathUseCase
    {
        private readonly IPlayerDeathRepository _repository;

        public PlayerDeathUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IPlayerDeathRepository>();
        }
        
        public bool Handle()
        {
            PlayerHp hp = _repository.GetHp();
            return hp == PlayerHp.Of(0);
        }
    }
}