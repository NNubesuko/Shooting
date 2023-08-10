﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.MovePlayer;
using UnityEngine;

namespace ShootingGame.Components.Player
{
    public class MovePlayerComponent : MonoBehaviour
    {
        [SerializeField] private PlayerStatusComponent _playerStatus;

        private IMovePlayerUseCase _movePlayerUseCase;
        private CancellationTokenSource _cancellation;

        private async void Start()
        {
            _movePlayerUseCase = SetUpDiContainer.ServiceProvider.GetService<IMovePlayerUseCase>();
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
                // プレイヤーの移動に使用するデータを作成する
                MovePlayerInputData inputData = MovePlayerInputData.Of(
                    transform.position,
                    _playerStatus.MoveSpeed,
                    _playerStatus.HorizontalMoveRange,
                    _playerStatus.VerticalMoveRange);
                // プレイヤーの処理を実行し、プレイヤーを移動させる
                transform.position = _movePlayerUseCase.Handle(inputData);
                
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }
        }

        private void OnDestroy()
        {
            _cancellation.Cancel();
        }
    }
}