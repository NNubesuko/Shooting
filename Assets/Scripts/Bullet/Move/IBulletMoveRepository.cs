using ShootingGame.Components.Bullet;

namespace ShootingGame.Bullet.Move
{
    public interface IBulletMoveRepository
    {
        /// <summary>
        /// 弾丸の移動速度を取得する
        /// </summary>
        /// <returns>弾丸の移動速度</returns>
        BulletMoveSpeed GetMoveSpeed(BulletStatus status);
    }
}