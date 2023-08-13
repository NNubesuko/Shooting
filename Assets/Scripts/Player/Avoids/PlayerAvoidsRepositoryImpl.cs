using ShootingGame.Components.Player;

namespace ShootingGame.Player.Avoids
{
    public class PlayerAvoidsRepositoryImpl : IPlayerAvoidsRepository
    {
        private readonly PlayerStatus _status;

        public PlayerAvoidsRepositoryImpl()
        {
            _status = PlayerStatus.Status;
        }
        
        public PlayerStamina GetStamina()
        {
            return PlayerStamina.Of(_status.Stamina);
        }
        
        public PlayerStamina GetConsumptionStamina()
        {
            return PlayerStamina.Of(_status.ConsumptionStamina);
        }

        public PlayerAvoidsSpeed GetAvoidsSpeed()
        {
            return PlayerAvoidsSpeed.Of(_status.AvoidsSpeed);
        }

        public PlayerAvoidsDistance GetAvoidsDistance()
        {
            return PlayerAvoidsDistance.Of(_status.AvoidsDistance);
        }

        public bool GetIsAvoiding()
        {
            return _status.IsAvoiding;
        }

        public void UpdateCanMove(bool canMove)
        {
            _status.CanMove = canMove;
        }

        public void UpdateStamina(PlayerStamina stamina)
        {
            _status.Stamina = stamina.Value;
        }

        public void UpdateIsAvoiding(bool isAvoiding)
        {
            _status.IsAvoiding = isAvoiding;
        }
    }
}