using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Player.PlayerRepository;
using UnityEngine;

namespace ShootingGame.Player.PlayerAvoids
{
    public class PlayerAvoidsUseCaseImpl : IPlayerAvoidsUseCase
    {
        private readonly IPlayerRepository _repository;

        private Vector2 _target;

        public PlayerAvoidsUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IPlayerRepository>();
        }

        public Vector2 Handle(PlayerAvoidsInputData inputData)
        {
            Vector2 position = inputData.Position;
            Vector2 moveDirection = inputData.MoveDirection;
            float deltaTime = inputData.DeltaTime;
            bool initiateAvoids = inputData.InitiateAvoids;

            bool isAvoiding = _repository.GetIsAvoiding();
            PlayerAvoidsSpeed avoidsSpeed = _repository.GetAvoidsSpeed();
            PlayerAvoidsDistance avoidsDistance = _repository.GetAvoidsDistance();
            PlayerStamina consumptionStamina = PlayerStamina.Of(10);
            PlayerStamina stamina = _repository.GetStamina();

            // 回避の入力があり
            // 移動していて
            // 回避していない状態であれば、回避する
            if (initiateAvoids && !isAvoiding && stamina != PlayerStamina.Of(0))
            {
                _target = position + avoidsDistance * moveDirection;
                _repository.UpdateIsAvoiding(true);
                // 回避中は移動を禁止する
                _repository.UpdateCanMove(false);
                // 回避分のスタミナを消費
                _repository.UpdateStamina(stamina - consumptionStamina);
            }

            // 回避先の位置に到着するまで回避を続ける
            if (position == _target)
            {
                _repository.UpdateIsAvoiding(false);
                // 回避が終了したら移動を可能にする
                _repository.UpdateCanMove(true);
            }
            
            if (isAvoiding)
            {
                return Vector2.MoveTowards(position, _target, avoidsSpeed * deltaTime);
            }
            
            return position;
        }
    }
}