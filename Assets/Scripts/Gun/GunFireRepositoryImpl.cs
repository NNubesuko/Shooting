using ShootingGame.Components.Gun;
using UnityEngine;

namespace ShootingGame.Gun
{
    public class GunFireRepositoryImpl : IGunFireRepository
    {
        private readonly GunStatus _status;

        public GunFireRepositoryImpl()
        {
            _status = GunStatus.Status;
        }
        
        public GameObject GetBulletObject()
        {
            return _status.BulletObject;
        }

        public BulletsCount GetBulletsCount()
        {
            return BulletsCount.Of(_status.BulletCount);
        }

        public BulletsMaxCount GetBulletsMaxCount()
        {
            return BulletsMaxCount.Of(_status.BulletMaxCount);
        }

        public GunFiringRate GetFireRate()
        {
            return GunFiringRate.Of(_status.FireRate);
        }

        public GunFiringRate GetCurrentFireRate()
        {
            return GunFiringRate.Of(_status.CurrentFireRate);
        }

        public void UpdateBulletsCount(BulletsCount count)
        {
            _status.BulletCount = count.Value;
        }

        public void UpdateCurrentFireRate(GunFiringRate currentFireRate)
        {
            _status.CurrentFireRate = currentFireRate.Value;
        }
    }
}