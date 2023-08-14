using System.Threading;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components.Player;
using ShootingGame.Gun;
using UnityEngine;

namespace ShootingGame.Components.Gun
{
    public class GunComponent : MonoBehaviour
    {
        private CancellationTokenSource _cancellation;
        private PlayerInputProvider _input;
        private IGunFireUseCase _fireUseCase;

        private async void Start()
        {
            _cancellation = new CancellationTokenSource();
            _input = PlayerInputProvider.PlayerInput;
            _fireUseCase = DiContainer.ServiceProvider.GetService<IGunFireUseCase>();
            
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
                Fire();
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }
        }

        private void Fire()
        {
            GunFireInputData inputData = GunFireInputData.Of(
                _input.Fire.Value,
                transform.position,
                Time.deltaTime,
                InstantiateMethod);
            
            _fireUseCase.Handle(inputData);
        }

        private void InstantiateMethod(GameObject gameObject, Vector2 position, Quaternion rotation)
        {
            Instantiate(gameObject, position, rotation);
        }

        private void OnDisable()
        {
            _cancellation.Cancel();
        }
    }
}