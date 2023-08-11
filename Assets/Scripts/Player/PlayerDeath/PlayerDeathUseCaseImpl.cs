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
        
        public void Handle(PlayerDeathInputData inputData)
        {
            GameObject gameObject = inputData.GameObject;
            PlayerHp hp = _repository.GetHp();

            if (hp == PlayerHp.Of(0))
            {
                gameObject.SetActive(false);
            }
        }
    }
}