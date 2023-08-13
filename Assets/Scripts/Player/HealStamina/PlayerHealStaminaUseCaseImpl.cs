using Microsoft.Extensions.DependencyInjection;
using UniRx;

namespace ShootingGame.Player.HealStamina
{
    public class PlayerHealStaminaUseCaseImpl : IPlayerHealStaminaUseCase
    {
        private readonly IPlayerHealStaminaRepository _repository;

        public PlayerHealStaminaUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IPlayerHealStaminaRepository>();
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