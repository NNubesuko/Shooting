using System;
using ShootingGame.Components.Player;

namespace ShootingGame.Player.PlayerRepository
{
    public class PlayerRepositoryImpl : IPlayerRepository
    {
        private readonly PlayerStatus _status;

        public PlayerRepositoryImpl()
        {
            _status = PlayerStatus.Status;
        }

        public PlayerAvoidsSpeed GetAvoidsSpeed()
        {
            return _status.AvoidsSpeed;
        }

        public PlayerAvoidsDistance GetAvoidsDistance()
        {
            return _status.AvoidsDistance;
        }

        public bool GetCanMove()
        {
            return _status.CanMove;
        }

        public void UpdateCanMove(bool canMove)
        {
            _status.CanMove = canMove;
        }

        public bool GetIsAvoiding()
        {
            return _status.IsAvoiding;
        }

        public void UpdateIsAvoiding(bool isAvoiding)
        {
            _status.IsAvoiding = isAvoiding;
        }
    }
}