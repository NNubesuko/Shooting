using ShootingGame.Components.Bullet;

namespace ShootingGame.Bullet.Attack
{
    public class BulletAttackRepositoryImpl : IBulletAttackRepository
    {
        public BulletAP GetAp(BulletStatus status)
        {
            return BulletAP.Of(status.Ap);
        }
    }
}