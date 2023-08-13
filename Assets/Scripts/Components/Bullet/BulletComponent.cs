using System.Threading;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Bullet.Move;
using UnityEngine;

namespace ShootingGame.Components.Bullet
{
    public class BulletComponent : MonoBehaviour
    {
        [SerializeField] private BulletStatus status;

        private CancellationTokenSource _cancellation;
        private IBulletMoveUseCase _moveUseCase;

        private async void Start()
        {
            _cancellation = new CancellationTokenSource();
            _moveUseCase = DiContainer.ServiceProvider.GetService<IBulletMoveUseCase>();

            try
            {
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
            BulletMoveInputData inputData = BulletMoveInputData.Of(
                status,
                transform.position,
                Time.deltaTime);
            
            transform.position = _moveUseCase.Handle(inputData);
        }

        private void OnDisable()
        {
            _cancellation.Cancel();
        }
    }
}