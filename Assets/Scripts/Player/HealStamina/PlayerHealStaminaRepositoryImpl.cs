using System;
using ShootingGame.Components.Player;

namespace ShootingGame.Player.HealStamina
{
    public class PlayerHealStaminaRepositoryImpl : IPlayerHealStaminaRepository
    {
        private readonly PlayerStatus _status;

        public PlayerHealStaminaRepositoryImpl()
        {
            _status = PlayerStatus.Status;
        }
        
        public PlayerStamina GetStamina()
        {
            return PlayerStamina.Of(_status.Stamina);
        }

        public PlayerStamina GetHealStamina()
        {
            return PlayerStamina.Of(_status.HealStamina);
        }

        public TimeSpan GetHealStaminaInterval()
        {
            return TimeSpan.FromSeconds(_status.HealStaminaInterval);
        }

        public void UpdateStamina(PlayerStamina stamina)
        {
            _status.Stamina = stamina.Value;
        }
    }
}