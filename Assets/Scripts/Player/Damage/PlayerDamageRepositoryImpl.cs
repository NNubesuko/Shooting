using ShootingGame.Components.Player;

namespace ShootingGame.Player.Damage
{
    public class PlayerDamageRepositoryImpl : IPlayerDamageRepository
    {
        private readonly PlayerStatus _status;

        public PlayerDamageRepositoryImpl()
        {
            _status = PlayerStatus.Status;
        }
        
        public PlayerHp GetHp()
        {
            return PlayerHp.Of(_status.Hp);
        }

        public void UpdateHp(PlayerHp hp)
        {
            _status.Hp = hp.Value;
        }
    }
}