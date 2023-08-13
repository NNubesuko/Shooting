using ShootingGame.Components.Player;

namespace ShootingGame.Player.HealStamina
{
    public class PlayerHealStaminaInputData
    {
        internal PlayerComponent PlayerComponent { get; }

        private PlayerHealStaminaInputData(PlayerComponent playerComponent)
        {
            PlayerComponent = playerComponent;
        }

        public static PlayerHealStaminaInputData Of(PlayerComponent playerComponent)
        {
            return new PlayerHealStaminaInputData(playerComponent);
        }
    }
}