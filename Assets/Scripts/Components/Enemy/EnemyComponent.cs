using System.Threading;
using Cysharp.Threading.Tasks;
using KataokaLib.System;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components.Player;
using ShootingGame.Enemy.Attack;
using ShootingGame.Enemy.Damage;
using ShootingGame.Enemy.Death;
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
        private IEnemyDamageUseCase _damageUseCase;
        private IEnemyDeathUseCase _deathUseCase;
        private IEnemyAttackUseCase _attackUseCase;

        private async void Start()
        {
            var serviceProvider = DiContainer.ServiceProvider;
            _cancellation = new CancellationTokenSource();
            _moveUseCase = serviceProvider.GetService<IEnemyMoveUseCase>();
            _updateTableIndexUseCase = serviceProvider.GetService<IEnemyUpdateTableIndexUseCase>();
            _damageUseCase = serviceProvider.GetService<IEnemyDamageUseCase>();
            _deathUseCase = serviceProvider.GetService<IEnemyDeathUseCase>();
            _attackUseCase = serviceProvider.GetService<IEnemyAttackUseCase>();
            
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
                Death();
                if (Inputk.GetKeyDown(KeyCode.L))
                {
                    EnemyAP ap = EnemyAP.Of(5);
                    Damage(ap);
                }
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

        private void Attack(IDamage player)
        {
            EnemyAttackInputData inputData = EnemyAttackInputData.Of(
                status,
                player);

            _attackUseCase.Handle(inputData);
        }

        public void Damage(Ap ap)
        {
            EnemyDamageInputData inputData = EnemyDamageInputData.Of(status, ap);
            _damageUseCase.Handle(inputData);
        }

        public void Death()
        {
            EnemyDeathInputData inputData = EnemyDeathInputData.Of(status);
            bool isDeath = _deathUseCase.Handle(inputData);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            GameObject gameObject = other.gameObject;
            if (gameObject.name.Equals("Player"))
            {
                Attack(gameObject.GetComponent<PlayerComponent>());
            }
        }

        private void OnDisable()
        {
            _cancellation.Cancel();
        }
    }
}