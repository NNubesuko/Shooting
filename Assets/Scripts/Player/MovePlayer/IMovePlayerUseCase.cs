using UnityEngine;

namespace ShootingGame.MovePlayer
{
    public interface IMovePlayerUseCase
    {
        Vector2 Handle(MovePlayerInputData inputData);
    }
}