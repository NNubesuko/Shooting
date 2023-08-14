using System.Threading;
using Cysharp.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Bullet.Attack;
using ShootingGame.Bullet.Move;
using ShootingGame.Components.Enemy;
using UnityEngine;

namespace ShootingGame.Components.Bullet
{
    public class BulletComponent : MonoBehaviour
    {
        [SerializeField] private BulletStatus status;

        private CancellationTokenSource _cancellation;
        private IBulletMoveUseCase _moveUseCase;
        private IBulletAttackUseCase _attackUseCase;

        private async void Start()
        {
            _cancellation = new CancellationTokenSource();

            var serviceProvider = DiContainer.ServiceProvider;
            _moveUseCase = serviceProvider.GetService<IBulletMoveUseCase>();
            _attackUseCase = serviceProvider.GetService<IBulletAttackUseCase>();

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

        private void Attack(IDamage enemy)
        {
            BulletAttackInputData inputData = BulletAttackInputData.Of(
                status,
                enemy);
            
            _attackUseCase.Handle(inputData);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            GameObject gameObject = other.gameObject;

            if (gameObject.CompareTag("Enemy"))
            {
                Attack(gameObject.GetComponent<EnemyComponent>());
                this.gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            _cancellation.Cancel();
        }
    }
}