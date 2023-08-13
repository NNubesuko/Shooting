using UnityEngine;

namespace ShootingGame.Player.PlayerAvoids
{
    public interface IPlayerAvoidsUseCase
    {
        Vector2 Handle(PlayerAvoidsInputData inputData);
    }
}