using ShootingGame.Components.Player;

namespace ShootingGame.Player.Death
{
    public class PlayerDeathRepositoryImpl : IPlayerDeathRepository
    {
        private readonly PlayerStatus _status;

        public PlayerDeathRepositoryImpl()
        {
            _status = PlayerStatus.Status;
        }

        public PlayerHp GetHp()
        {
            return PlayerHp.Of(_status.Hp);
        }
    }
}