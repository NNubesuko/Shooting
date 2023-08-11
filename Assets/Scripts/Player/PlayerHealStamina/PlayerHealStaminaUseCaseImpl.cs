using Cysharp.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Player.PlayerRepository;
using UniRx;
using UnityEngine;
using ObservableExtensions = UniRx.ObservableExtensions;

namespace ShootingGame.Player.PlayerHealStamina
{
    public class PlayerHealStaminaUseCaseImpl : IPlayerHealStaminaUseCase
    {
        private readonly IPlayerRepository _repository;

        public PlayerHealStaminaUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IPlayerRepository>();
        }
        
        public void Handle(PlayerHealStaminaInputData inputData)
        {
            System.TimeSpan interval = _repository.GetHealStaminaInterval();

            Observable.Timer(System.TimeSpan.Zero, interval)
                .Subscribe(
                    _ =>
                    {
                        PlayerStamina stamina = _repository.GetStamina();
                        PlayerStamina healStamina = _repository.GetHealStamina();
                        _repository.UpdateStamina(stamina + healStamina);
                    }
                ).AddTo(inputData.PlayerComponent);
        }
    }
}