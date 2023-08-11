using ShootingGame.Components.Player;
using UnityEngine;

namespace ShootingGame.Player.PlayerRepository
{
    public class PlayerRepositoryImpl : IPlayerRepository
    {
        private readonly PlayerStatus _status;

        public PlayerRepositoryImpl()
        {
            _status = PlayerStatus.Status;
        }

        public PlayerHp GetHp()
        {
            return _status.Hp;
        }
        
        public PlayerMoveSpeed GetMoveSpeed()
        {
            return _status.MoveSpeed;
        }

        public PlayerHorizontalMoveRange GetHorizontalMoveRange()
        {
            return _status.HorizontalMoveRange;
        }

        public PlayerVerticalMoveRange GetVerticalMoveRange()
        {
            return _status.VerticalMoveRange;
        }

        public void UpdateHp(PlayerHp hp)
        {
            _status.Hp = hp;
        }
    }
}