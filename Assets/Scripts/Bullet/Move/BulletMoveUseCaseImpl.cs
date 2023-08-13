using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components.Bullet;
using UnityEngine;

namespace ShootingGame.Bullet.Move
{
    public class BulletMoveUseCaseImpl : IBulletMoveUseCase
    {
        private readonly IBulletMoveRepository _repository;

        public BulletMoveUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IBulletMoveRepository>();
        }
        
        public Vector2 Handle(BulletMoveInputData inputData)
        {
            BulletStatus status = inputData.Status;
            Vector2 position = inputData.Position;
            float deltaTime = inputData.DeltaTime;
            BulletMoveSpeed moveSpeed = _repository.GetMoveSpeed(status);

            position.y += moveSpeed * deltaTime;
            return position;
        }
    }
}