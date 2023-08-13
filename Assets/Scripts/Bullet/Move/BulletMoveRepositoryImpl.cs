using ShootingGame.Components.Bullet;

namespace ShootingGame.Bullet.Move
{
    public class BulletMoveRepositoryImpl : IBulletMoveRepository
    {
        public BulletMoveSpeed GetMoveSpeed(BulletStatus status)
        {
            return BulletMoveSpeed.Of(status.MoveSpeed);
        }
    }
}