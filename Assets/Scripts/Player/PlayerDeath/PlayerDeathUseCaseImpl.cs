using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Player.PlayerRepository;
using UnityEngine;

namespace ShootingGame.Player.PlayerDeath
{
    public class PlayerDeathUseCaseImpl : IPlayerDeathUseCase
    {
        private readonly IPlayerRepository _repository;

        public PlayerDeathUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IPlayerRepository>();
        }
        
        public bool Handle()
        {
            PlayerHp hp = _repository.GetHp();
            return hp == PlayerHp.Of(0);
        }
    }
}