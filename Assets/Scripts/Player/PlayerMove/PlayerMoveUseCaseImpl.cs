using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Player.PlayerRepository;
using UnityEngine;

namespace ShootingGame.PlayerMove
{
    public class PlayerMoveUseCaseImpl : IPlayerMoveUseCase
    {
        private readonly IPlayerRepository _repository;

        public PlayerMoveUseCaseImpl()
        {
            _repository = DiContainer.ServiceProvider.GetService<IPlayerRepository>();
        }

        public Vector2 Handle(PlayerMoveInputData inputData)
        {
            Vector2 position = inputData.Position;
            Vector2 axis = inputData.Axis;
            float deltaTime = inputData.DeltaTime;
            
            PlayerMoveSpeed moveSpeed = _repository.GetMoveSpeed();
            PlayerHorizontalMoveRange horizontalMoveRange = _repository.GetHorizontalMoveRange();
            PlayerVerticalMoveRange verticalMoveRange = _repository.GetVerticalMoveRange();

            Vector2 velocity = position + moveSpeed * axis * deltaTime;
            velocity.x = horizontalMoveRange.WithinRange(velocity.x);
            velocity.y = verticalMoveRange.WithinRange(velocity.y);

            return velocity;
        }
    }
}