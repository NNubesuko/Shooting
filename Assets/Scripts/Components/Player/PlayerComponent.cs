using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using KataokaLib.System;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Player.DamagePlayerComponent;
using ShootingGame.Player.PlayerAvoids;
using ShootingGame.Player.PlayerDeath;
using ShootingGame.PlayerMove;
using UnityEngine;

namespace ShootingGame.Components.Player
{
    public class PlayerComponent : MonoBehaviour, IDamage
    {
        private CancellationTokenSource _cancellation;
        private IPlayerMoveUseCase _moveUseCase;
        // private IPlayerAvoidsUseCase _avoidsUseCase;
        private IPlayerDamageUseCase _damageUseCase;
        private IPlayerDeathUseCase _deathUseCase;

        private void Awake()
        {
            _cancellation = new CancellationTokenSource();
        }

        private async void Start()
        {
            var serviceProvider = DiContainer.ServiceProvider;
            _moveUseCase = serviceProvider.GetService<IPlayerMoveUseCase>();
            // _avoidsUseCase = serviceProvider.GetService<IPlayerAvoidsUseCase>();
            _damageUseCase = serviceProvider.GetService<IPlayerDamageUseCase>();
            _deathUseCase = serviceProvider.GetService<IPlayerDeathUseCase>();

            try
            {
                await UniTaskUpdate(_cancellation.Token);
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Death");
            }
        }

        private async UniTask UniTaskUpdate(CancellationToken token)
        {
            while (true)
            {
                Move();
                Death();

                if (Inputk.GetKeyDown(KeyCode.L))
                {
                    EnemyAP ap = EnemyAP.Of(10);
                    Damage(ap);
                }
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }
        }

        private void Move()
        {
            PlayerMoveInputData inputData = PlayerMoveInputData.Of(
                transform.position,
                Inputk.GetAxis(),
                Time.deltaTime);
            
            transform.position = _moveUseCase.Handle(inputData);
        }

        public void Damage(Ap ap)
        {
            PlayerDamageInputData inputData = PlayerDamageInputData.Of(ap);
            _damageUseCase.Handle(inputData);
        }

        public void Death()
        {
            bool isDeath = _deathUseCase.Handle();

            if (isDeath)
            {
                gameObject.SetActive(false);
            }
        }

        // public void Avoids()
        // {
        //     PlayerAvoidsInputData inputData = PlayerAvoidsInputData.Of(
        //         transform.position,
        //         Time.deltaTime,
        //         _avoidsSpeed,
        //         _avoidsDistance);
        //
        //     var (updatePosition, isAvoiding) = _avoidsUseCase.Handle(inputData);
        //     _isAvoiding = isAvoiding;
        //     
        //     // 回避していたら位置を更新する
        //     if (_isAvoiding)
        //     {
        //         transform.position = updatePosition;
        //     }
        // }

        private void OnDisable() => _cancellation.Cancel();
    }
}