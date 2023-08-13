using ShootingGame.Components.Player;

namespace ShootingGame.Player.Move
{
    public class PlayerMoveRepositoryImpl : IPlayerMoveRepository
    {
        private PlayerStatus _status;

        public PlayerMoveRepositoryImpl()
        {
            _status = PlayerStatus.Status;
        }
        
        public PlayerMoveSpeed GetMoveSpeed()
        {
            return PlayerMoveSpeed.Of(_status.MoveSpeed);
        }
    }
}