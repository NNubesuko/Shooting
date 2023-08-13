using System.ComponentModel;
using System.Threading;
using Cysharp.Threading.Tasks;
using KataokaLib.System;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Player.Damage;
using ShootingGame.Player.PlayerAvoids;
using ShootingGame.Player.Death;
using ShootingGame.Player.PlayerHealStamina;
using ShootingGame.Player.Move;
using UniRx;
using UnityEngine;

namespace ShootingGame.Components.Player
{
    public class PlayerComponent : MonoBehaviour, IDamage
    {
        private CancellationTokenSource _cancellation;

        private PlayerInputProvider _input;
        private IPlayerMoveUseCase _moveUseCase;
        private IPlayerHealStaminaUseCase _healStaminaUseCase;
        private IPlayerAvoidsUseCase _avoidsUseCase;
        private IPlayerDamageUseCase _damageUseCase;
        private IPlayerDeathUseCase _deathUseCase;

        private void Awake()
        {
            _cancellation = new CancellationTokenSource();
        }

        private async void Start()
        {
            var serviceProvider = DiContainer.ServiceProvider;

            _input = PlayerInputProvider.PlayerInput;
            _moveUseCase = serviceProvider.GetService<IPlayerMoveUseCase>();
            _healStaminaUseCase = serviceProvider.GetService<IPlayerHealStaminaUseCase>();
            _avoidsUseCase = serviceProvider.GetService<IPlayerAvoidsUseCase>();
            _damageUseCase = serviceProvider.GetService<IPlayerDamageUseCase>();
            _deathUseCase = serviceProvider.GetService<IPlayerDeathUseCase>();

            try
            {
                HealStamina();
                await UniTaskUpdate(_cancellation.Token);
            }
            catch (System.OperationCanceledException)
            {
                Debug.Log("Death");
            }
        }

        private async UniTask UniTaskUpdate(CancellationToken token)
        {
            while (true)
            {
                Move();
                Avoids();
                Death();
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }
        }

        private void Move()
        {
            PlayerMoveInputData inputData = PlayerMoveInputData.Of(
                transform.position,
                _input.MoveDirection.Value,
                Time.deltaTime);
            
            transform.position = _moveUseCase.Handle(inputData);
        }

        private void HealStamina()
        {
            PlayerHealStaminaInputData inputData = PlayerHealStaminaInputData.Of(this);
            _healStaminaUseCase.Handle(inputData);
        }

        private void Avoids()
        {
            PlayerAvoidsInputData inputData = PlayerAvoidsInputData.Of(
                transform.position,
                _input.MoveDirection.Value,
                Time.deltaTime,
                _input.Avoids.Value);
            
            transform.position = _avoidsUseCase.Handle(inputData);
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

        private void OnDisable() => _cancellation.Cancel();
    }
}