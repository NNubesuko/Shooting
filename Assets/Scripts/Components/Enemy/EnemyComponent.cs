using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Enemy.Move;
using ShootingGame.Enemy.UpdateTableIndex;
using UnityEngine;

namespace ShootingGame.Components.Enemy
{
    public class EnemyComponent : MonoBehaviour, IDamage
    {
        [SerializeField] private EnemyStatus status;
        
        private CancellationTokenSource _cancellation;
        private IEnemyMoveUseCase _moveUseCase;
        private IEnemyUpdateTableIndexUseCase _updateTableIndexUseCase;

        private void Awake()
        {
            _cancellation = new CancellationTokenSource();
        }

        private async void Start()
        {
            var serviceProvider = DiContainer.ServiceProvider;
            _moveUseCase = serviceProvider.GetService<IEnemyMoveUseCase>();
            _updateTableIndexUseCase = serviceProvider.GetService<IEnemyUpdateTableIndexUseCase>();
            
            try
            {
                UpdateTableIndex();
                await UniTaskUpdate(_cancellation.Token);
            }
            catch (System.OperationCanceledException)
            {
            }
        }

        private async UniTask UniTaskUpdate(CancellationToken token)
        {
            while (true)
            {
                Move();
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }
        }

        private void Move()
        {
            EnemyMoveInputData inputData = EnemyMoveInputData.Of(
                transform.position,
                Time.deltaTime,
                status);
            
            transform.position = _moveUseCase.Handle(inputData);
        }

        private void UpdateTableIndex()
        {
            EnemyUpdateTableIndexInputData inputData = EnemyUpdateTableIndexInputData.Of(
                this,
                status);
            
            _updateTableIndexUseCase.Handle(inputData);
        }

        public void Damage(Ap ap)
        {
        }

        public void Death()
        {
        }

        private void OnDisable()
        {
            _cancellation.Cancel();
        }
    }
}