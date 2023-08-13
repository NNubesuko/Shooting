using ShootingGame.Components.Bullet;

namespace ShootingGame.Bullet.Attack
{
    public interface IBulletAttackRepository
    {
        /// <summary>
        /// 弾丸の攻撃力を取得する
        /// </summary>
        /// <returns>弾丸の攻撃力</returns>
        BulletAP GetAp(BulletStatus status);
    }
}