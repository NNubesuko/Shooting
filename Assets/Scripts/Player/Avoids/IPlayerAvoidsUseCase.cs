using UnityEngine;

namespace ShootingGame.Player.Avoids
{
    public interface IPlayerAvoidsUseCase
    {
        Vector2 Handle(PlayerAvoidsInputData inputData);
    }
}