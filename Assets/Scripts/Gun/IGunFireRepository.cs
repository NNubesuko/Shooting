using UnityEngine;

namespace ShootingGame.Gun
{
    public interface IGunFireRepository
    {
        /// <summary>
        /// 弾丸のゲームオブジェクトを取得する
        /// </summary>
        /// <returns>弾丸のゲームオブジェクト</returns>
        GameObject GetBulletObject();
        
        /// <summary>
        /// 現在の発砲数を取得する
        /// </summary>
        /// <returns>現在の発砲数</returns>
        BulletsCount GetBulletsCount();
        
        /// <summary>
        /// 発射できる弾丸の最大数を取得する
        /// </summary>
        /// <returns>発射できる弾丸の最大数</returns>
        BulletsMaxCount GetBulletsMaxCount();
        
        /// <summary>
        /// 銃の発射レートを取得する
        /// </summary>
        /// <returns>銃の発射レート</returns>
        GunFiringRate GetFireRate();

        /// <summary>
        /// 現在のレートを取得する
        /// </summary>
        /// <returns>現在のレート</returns>
        GunFiringRate GetCurrentFireRate();

        /// <summary>
        /// 弾丸の発砲数を更新する
        /// </summary>
        /// <param name="count">更新する弾丸の発射数</param>
        void UpdateBulletsCount(BulletsCount count);

        /// <summary>
        /// 現在のレートを更新する
        /// </summary>
        /// <param name="currentFireRate">更新するレート</param>
        void UpdateCurrentFireRate(GunFiringRate currentFireRate);
    }
}