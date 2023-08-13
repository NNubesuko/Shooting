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

        public PlayerHorizontalMoveRange GetHorizontalMoveRange()
        {
            return PlayerHorizontalMoveRange.Of(
                _status.StartHorizontalMoveRange,
                _status.EndHorizontalRange);
        }

        public PlayerVerticalMoveRange GetVerticalMoveRange()
        {
            return PlayerVerticalMoveRange.Of(
                _status.StartVerticalMoveRange,
                _status.EndVerticalRange);
        }

        public bool GetCanMove()
        {
            return _status.CanMove;
        }
    }
}