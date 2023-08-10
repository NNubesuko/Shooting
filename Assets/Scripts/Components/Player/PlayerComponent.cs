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
        [SerializeField] private int hp;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float stamina;
        [SerializeField] private float avoidsSpeed;
        [SerializeField] private float avoidsDistance;
        [SerializeField] private float startHorizontalRange;
        [SerializeField] private float endHorizontalRange;
        [SerializeField] private float startVerticalRange;
        [SerializeField] private float endVerticalRange;

        private PlayerHp _hp;
        private PlayerMoveSpeed _moveSpeed;
        private PlayerStamina _stamina;
        private PlayerAvoidsSpeed _avoidsSpeed;
        private PlayerAvoidsDistance _avoidsDistance;
        private PlayerHorizontalMoveRange _horizontalMoveRange;
        private PlayerVerticalMoveRange _verticalMoveRange;
        private CancellationTokenSource _cancellation;

        private IPlayerMoveUseCase _moveUseCase;
        private IPlayerAvoidsUseCase _avoidsUseCase;
        private IPlayerDamageUseCase _damageUseCase;
        private IPlayerDeathUseCase _deathUseCase;

        private void Awake()
        {
            _hp = PlayerHp.Of(hp);
            _moveSpeed = PlayerMoveSpeed.Of(moveSpeed);
            _stamina = PlayerStamina.Of(stamina);
            _avoidsSpeed = PlayerAvoidsSpeed.Of(avoidsSpeed);
            _avoidsDistance = PlayerAvoidsDistance.Of(avoidsDistance);
            _horizontalMoveRange = PlayerHorizontalMoveRange.Of(startHorizontalRange, endHorizontalRange);
            _verticalMoveRange = PlayerVerticalMoveRange.Of(startVerticalRange, endVerticalRange);

            _cancellation = new CancellationTokenSource();
        }

        private async void Start()
        {
            var serviceProvider = DiContainer.ServiceProvider;
            _moveUseCase = serviceProvider.GetService<IPlayerMoveUseCase>();
            _avoidsUseCase = serviceProvider.GetService<IPlayerAvoidsUseCase>();
            _damageUseCase = serviceProvider.GetService<IPlayerDamageUseCase>();
            _deathUseCase = serviceProvider.GetService<IPlayerDeathUseCase>();

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
                Time.deltaTime,
                _moveSpeed,
                _horizontalMoveRange,
                _verticalMoveRange);
            
            transform.position = _moveUseCase.Handle(inputData);
        }

        public void Avoids()
        {
            if (Inputk.GetKeyDown(KeyCode.Space))
            {
                PlayerAvoidsInputData inputData = PlayerAvoidsInputData.Of(
                    transform.position,
                    Time.deltaTime,
                    _avoidsSpeed,
                    _avoidsDistance);
                
                transform.position = _avoidsUseCase.Handle(inputData);
            }
        }

        public void Damage(Ap ap)
        {
            PlayerDamageInputData inputData = PlayerDamageInputData.Of(_hp, ap);
            _hp = _damageUseCase.Handle(inputData);
        }

        public void Death()
        {
            PlayerDeathInputData input = PlayerDeathInputData.Of(gameObject, _hp);
            _deathUseCase.Handle(input);
        }

        private void OnDestroy() => _cancellation.Cancel();
    }
}