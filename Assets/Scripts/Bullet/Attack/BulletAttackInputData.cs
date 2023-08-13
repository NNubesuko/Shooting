using ShootingGame.Components;
using ShootingGame.Components.Bullet;

namespace ShootingGame.Bullet.Attack
{
    public class BulletAttackInputData
    {
        internal BulletStatus Status { get; }
        internal IDamage Enemy { get; }

        private BulletAttackInputData(BulletStatus status, IDamage enemy)
        {
            Status = status;
            Enemy = enemy;
        }

        public static BulletAttackInputData Of(BulletStatus status, IDamage enemy)
        {
            return new BulletAttackInputData(status, enemy);
        }
    }
}