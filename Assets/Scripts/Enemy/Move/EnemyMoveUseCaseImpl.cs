using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components.Enemy;
using UnityEngine;

namespace ShootingGame.Enemy.Move
{
    public class EnemyMoveUseCaseImpl : IEnemyMoveUseCase
    {
        private readonly IEnemyMoveRepository _repository;

        private Vector2 _lastPosition;
        private Vector2 _p;

        public EnemyMoveUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IEnemyMoveRepository>();
        }
        
        public Vector2 Handle(EnemyMoveInputData inputData)
        {
            Vector2 position = inputData.Position;
            float deltaTime = inputData.DeltaTime;
            EnemyStatus status = inputData.Status;

            EnemyMoveSpeed moveSpeed = _repository.GetMoveSpeed(status);
            Vector2[] targetTable = _repository.GetTargetTable(status);
            int tableIndex = _repository.GetTableIndex(status);

            Vector2 velocity = _lastPosition = position;
            _p += moveSpeed * (targetTable[tableIndex] - velocity) * deltaTime;
            _p -= 1 * _p * Time.deltaTime;
            velocity += _p * Time.deltaTime;
            
            return velocity;
        }
    }
}