using System.Threading;
using Cysharp.Threading.Tasks;
using KataokaLib.System;
using UniRx;
using UnityEngine;

namespace ShootingGame.Components.Player
{
    public class PlayerInputProvider : MonoBehaviour
    {
        public static PlayerInputProvider PlayerInput { get; private set; }

        public IReadOnlyReactiveProperty<Vector2> MoveDirection => _moveDirection;
        public IReadOnlyReactiveProperty<bool> Avoids => _avoids;
        public IReadOnlyReactiveProperty<bool> Fire => _fire;


        private CancellationTokenSource _cancellation;
        private readonly ReactiveProperty<Vector2> _moveDirection = new ReactiveProperty<Vector2>();
        private readonly ReactiveProperty<bool> _avoids = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _fire = new BoolReactiveProperty();

        private async void Awake()
        {
            PlayerInput = this;
            
            _cancellation = new CancellationTokenSource();
            _moveDirection.AddTo(this);
            _avoids.AddTo(this);
            _fire.AddTo(this);

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
                _moveDirection.Value = Inputk.GetAxis();
                _avoids.Value = Inputk.GetKeyDown(KeyCode.Space) && Inputk.IsMoving();
                _fire.Value = Inputk.GetKeyDown(KeyCode.Return);
                
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }
        }

        private void OnDestroy()
        {
            _moveDirection.Dispose();
            _avoids.Dispose();
            _fire.Dispose();
            _cancellation.Cancel();
        }
    }
}