using Microsoft.Extensions.DependencyInjection;
using UnityEngine;

namespace ShootingGame.Gun
{
    public class GunFireUseCaseImpl : IGunFireUseCase
    {
        private readonly IGunFireRepository _repository;

        public GunFireUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IGunFireRepository>();
        }

        public void Handle(GunFireInputData inputData)
        {
            BulletsCount count = _repository.GetBulletsCount();
            BulletsMaxCount maxCount = _repository.GetBulletsMaxCount();
            if (count >= maxCount)
                return;

            bool isFiring = inputData.IsFiring;
            float deltaTime = inputData.DeltaTime;
            GunFiringRate fireRate = _repository.GetFireRate();
            GunFiringRate currentRate = _repository.GetCurrentFireRate();
            
            // レートを増やす
            _repository.UpdateCurrentFireRate(currentRate + deltaTime);

            if (isFiring && fireRate <= currentRate)
            {
                // 発射数を増やす
                _repository.UpdateBulletsCount(++count);
                // 現在のレートを初期化
                _repository.UpdateCurrentFireRate(GunFiringRate.Of(0));

                // 弾丸のオブジェクトを生成
                GunFireInputData.Instantiate instantiateMethod = inputData.InstantiateMethod;
                GameObject bulletObject = _repository.GetBulletObject();
                Vector2 position = inputData.Position;
                instantiateMethod(bulletObject, position, Quaternion.identity);
            }
        }
    }
}