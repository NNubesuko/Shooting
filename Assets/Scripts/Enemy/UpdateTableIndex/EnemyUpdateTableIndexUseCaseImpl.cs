using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components.Enemy;
using UniRx;
using UnityEngine;

namespace ShootingGame.Enemy.UpdateTableIndex
{
    public class EnemyUpdateTableIndexUseCaseImpl : IEnemyUpdateTableIndexUseCase
    {
        private IEnemyUpdateTableIndexRepository _repository;

        public EnemyUpdateTableIndexUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IEnemyUpdateTableIndexRepository>();
        }

        public void Handle(EnemyUpdateTableIndexInputData inputData)
        {
            EnemyStatus status = inputData.Status;
            System.TimeSpan updateTableIndexInterval = _repository.GetUpdateTableIndexInterval(status);
            Observable.Timer(updateTableIndexInterval, updateTableIndexInterval)
                .Subscribe(_ =>
                {
                    Vector2[] targetTable = _repository.GetTargetTable(status);
                    int tableIndex = _repository.GetTableIndex(status);
                    _repository.UpdateTableIndex(status, (tableIndex + 1) % targetTable.Length);
                }).AddTo(inputData.EnemyComponent);
        }
    }
}