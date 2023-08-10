using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.MovePlayer;
using UnityEngine;

namespace ShootingGame.Components.Player
{
    public class MovePlayerComponent : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float startHorizontalRange;
        [SerializeField] private float endHorizontalRange;
        [SerializeField] private float startVerticalRange;
        [SerializeField] private float endVerticalRange;

        private PlayerMoveSpeed _moveSpeed;
        private PlayerHorizontalMoveRange _horizontalMoveRange;
        private PlayerVerticalMoveRange _verticalMoveRange;

        private IMovePlayerUseCase _movePlayerUseCase;
        private CancellationTokenSource _cancellation;

        private void Awake()
        {
            _moveSpeed = PlayerMoveSpeed.Of(moveSpeed);
            _horizontalMoveRange = PlayerHorizontalMoveRange.Of(startHorizontalRange, endHorizontalRange);
            _verticalMoveRange = PlayerVerticalMoveRange.Of(startVerticalRange, endVerticalRange);
        }

        private async void Start()
        {
            _movePlayerUseCase = SetUpDiContainer.ServiceProvider.GetService<IMovePlayerUseCase>();
            _cancellation = new CancellationTokenSource();
            
            CancellationToken token = _cancellation.Token;
            try
            {
                await UniTaskUpdate(token);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async UniTask UniTaskUpdate(CancellationToken token)
        {
            while (true)
            {
                MovePlayerInputData inputData =
                    MovePlayerInputData.Of(transform.position, _moveSpeed, _horizontalMoveRange, _verticalMoveRange);
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