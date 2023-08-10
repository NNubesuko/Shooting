using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Player.DeathPlayer;
using UnityEngine;

namespace ShootingGame.Components.Player
{
    public class DeathPlayerComponent : MonoBehaviour
    {
        [SerializeField] private PlayerStatusComponent _playerStatus;

        private IDeathPlayerUseCase _deathPlayerUseCase;
        private CancellationTokenSource _cancellation;

        private async void Start()
        {
            _deathPlayerUseCase = SetUpDiContainer.ServiceProvider.GetService<IDeathPlayerUseCase>();
            _cancellation = new CancellationTokenSource();
            
            try
            {
                await UniTaskUpdate(_cancellation.Token);
            }
            catch (OperationCanceledException)
            {
            }
        }
        
        private async UniTask UniTaskUpdate(CancellationToken token)
        {
            while (true)
            {
                // プレイヤーの死亡判定に使用するデータを作成
                DeathPlayerInputData inputData = DeathPlayerInputData.Of(gameObject, _playerStatus.Hp);
                // プレイヤーの死亡判定処理を実行し、判定を格納する
                _playerStatus.IsDeath = _deathPlayerUseCase.Handle(inputData);
        
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }
        }
        
        private void OnDestroy()
        {
            _cancellation.Cancel();
        }
    }
}